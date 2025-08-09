////////////////////////////////////////////////////////////////////////////////
//
//    Read Tags
//
////////////////////////////////////////////////////////////////////////////////

using System;
using Impinj.OctaneSdk;
using System.IO;
using System.Collections.Generic;

namespace OctaneSdkExamples
{
    class Program
    {
        // Replace with your reader's IP address or hostname
        private const string ReaderHostname = "SpeedwayR-16-50-19";

        private static ImpinjReader reader = new ImpinjReader();
        private static int tagCounter = 1; // To generate unique EPCs
        private static readonly object lockObject = new object();
        //private static HashSet<string> programmedEpcs = new HashSet<string>(); 
        private static Dictionary<string, Tag> programmedEpcs = new Dictionary<string, Tag>();// Keep track of already programmed tags
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the starting number: ");
                tagCounter = int.Parse(Console.ReadLine());
                // Connect to the reader
                Console.WriteLine($"Connecting to reader at {ReaderHostname}...");
                reader.Connect(ReaderHostname);
                Console.WriteLine("Connected to reader.");

                // Assign event handlers
                reader.TagsReported += OnTagsReported;
                reader.TagOpComplete += OnTagOpComplete;

                // Configure reader settings for continuous inventory
                Settings settings = reader.QueryDefaultSettings();

                settings.Report.IncludeAntennaPortNumber = true;
                settings.Report.IncludePeakRssi = true;
                settings.Report.IncludePcBits = true; // Essential for correct EPC writing
                settings.Report.IncludeFirstSeenTime = true;
                settings.Report.IncludeLastSeenTime = true;

                // Set reader mode for good performance
                settings.ReaderMode = ReaderMode.AutoSetDenseReader;

                // Enable all antennas
                settings.Antennas.DisableAll();
                for (ushort i = 1; i <= 1; i++) // Let's program with only 1 (up to 4 antennas)
                {
                    settings.Antennas.GetAntenna(i).IsEnabled = true;
                    settings.Antennas.GetAntenna(i).TxPowerInDbm = 24; //  30 =Max power (adjust as needed)
                    settings.Antennas.GetAntenna(i).RxSensitivityInDbm = -70; // Good sensitivity (adjust as needed)
                }

                // Apply settings
                reader.ApplySettings(settings);

                Console.WriteLine("Starting inventory (reading tags)...");
                reader.Start();

                int nextNum = tagCounter;
                while (nextNum > 0)
                {
                    Console.WriteLine("Enter next tag # or <Enter> to skip to next. 0 to quit");
                    string ans = Console.ReadLine();
                    if (ans == "")
                    {
                        tagCounter++;
                        continue;
                    }
                    int.TryParse(ans, out nextNum);
                    tagCounter = nextNum;
                }

               
                Console.WriteLine("Stopping reader...");
                reader.Stop();

                Console.WriteLine("Disconnecting from reader...");
                reader.Disconnect();
                Console.WriteLine("Disconnected.");
            }
            catch (OctaneSdkException e)
            {
                Console.WriteLine($"Octane SDK Exception: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }

            Console.WriteLine("Program finished.");
            Console.ReadKey();
        }

        static void OnTagsReported(ImpinjReader sender, TagReport report)
        {
            foreach (Tag tag in report.Tags)
            {
                //Console.WriteLine($"\nTag found: EPC = {tag.Epc.ToHexString()}, Antenna = {tag.AntennaPortNumber}");

                // Only process tags that haven't been programmed yet in this run
                lock (lockObject)
                {
                    if (programmedEpcs.ContainsKey(tag.Epc.ToHexString()))
                    {
                        continue;
                        Console.WriteLine($"{tag.Epc.ToHexString()}Already seen.");
                    }
                }


                // Generate a new, unique EPC (example: sequential numbers)
                string newEpcHexString;
                lock (lockObject)
                {
                    // make the Hex look like a decimal for timing system
                    int value = Convert.ToInt32(tagCounter.ToString(), 16);

                    // A simple sequential EPC. Real-world EPCs are more complex (GS1, etc.)
                    // Ensure the new EPC has a valid length (e.g., 24 hex characters for 96-bit EPC)
                    newEpcHexString = $"30000000000000000000{value:X12}";
                    // Pad with leading zeros to make it 24 characters (96 bits) if needed.
                    newEpcHexString = newEpcHexString.Substring(newEpcHexString.Length - 24);
                }

                //Console.WriteLine($"Attempting to program tag {tag.Epc.ToHexString()} to new EPC: {newEpcHexString}...");

                try
                {
                    ProgramTagEpc(tag.Epc.ToHexString(), tag, newEpcHexString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error scheduling write for tag {tag.Epc.ToHexString()}: {ex.Message}");
                }
            }
        }

        static void ProgramTagEpc(string currentEpcHexString, Tag currentTag, string newEpcHexString)
        {
            TagOpSequence seq = new TagOpSequence();

            // Set the target tag: We target the tag with its CURRENT EPC.
            // This ensures we write to the specific tag we just read.
            seq.TargetTag.MemoryBank = MemoryBank.Epc;
            seq.TargetTag.BitPointer = BitPointers.Epc;
            seq.TargetTag.Data = currentEpcHexString;

            // Set BlockWriteEnabled for better performance on supporting tags (Monza 4, 5, X)
            // seq.BlockWriteEnabled = true;
            // seq.BlockWriteWordCount = 2; // For 32-bit block writes

            // 1. Create the EPC write operation
            TagWriteOp writeEpcOp = new TagWriteOp();
            writeEpcOp.Id = 123; // A unique ID for this operation instance
            writeEpcOp.MemoryBank = MemoryBank.Epc;
            writeEpcOp.WordPointer = WordPointers.Epc; // Start writing after CRC and PC bits
            writeEpcOp.Data = TagData.FromHexString(newEpcHexString);
            seq.Ops.Add(writeEpcOp);

            // 2. Adjust and write PC bits if the EPC length changes
            // EPC length in words (1 word = 16 bits = 4 hex characters)
            ushort newEpcLenWords = (ushort)(newEpcHexString.Length / 4);
            ushort newPcBits = PcBits.AdjustPcBits(currentTag.PcBits , newEpcLenWords);

            // Only write PC bits if they actually need to change
            if (newPcBits != currentTag.PcBits)
            {
                Console.WriteLine($"  -> Also updating PC bits from {currentTag.PcBits:X4} to {newPcBits:X4} due to EPC length change.");
                TagWriteOp writePcOp = new TagWriteOp();
                writePcOp.Id = 456; // Another unique ID
                writePcOp.MemoryBank = MemoryBank.Epc;
                writePcOp.WordPointer = WordPointers.PcBits; // Start writing at the PC bits
                writePcOp.Data = TagData.FromWord(newPcBits);
                seq.Ops.Add(writePcOp);
            }

            // Add the operation sequence to the reader.
            // The reader will queue this operation and execute it when the target tag is in range.
            reader.AddOpSequence(seq);

            // Add the original EPC and new EPC to the list of programmed EPCs to avoid re-programming it repeatedly
            lock (lockObject)
            {
                programmedEpcs.Add(currentEpcHexString,currentTag);
                programmedEpcs.Add(newEpcHexString, currentTag);
            }
        }

        static void OnTagOpComplete(ImpinjReader reader, TagOpReport report)
        {
            foreach (TagOpResult result in report.Results)
            {
                if (result is TagWriteOpResult writeResult)
                {
                    if (writeResult.OpId == 123) // Our EPC write operation
                    {
                        //Console.WriteLine($"  -> EPC write for {writeResult.Tag.Epc.ToHexString()} complete. Status: {writeResult.Result}");
                        if (writeResult.Result == WriteResultStatus.Success)
                        {
                            Console.WriteLine($"  -> Tag {writeResult.Tag.Epc.ToHexString()} successfully programmed!");
                            Console.Beep();
                            tagCounter++; // only increment when successful
                        }
                        else
                        {
                            Console.WriteLine($"  -> Failed to program tag {writeResult.Tag.Epc.ToHexString()}. Status: {writeResult.Result}");
                            // If a write fails, remove from programmedEpcs so it can be reattempted
                            lock (lockObject)
                            {
                                programmedEpcs.Remove(writeResult.Tag.Epc.ToHexString());
                            }
                        }
                    }
                    else if (writeResult.OpId == 456) // Our PC bits write operation
                    {
                        Console.WriteLine($"  -> PC bits write for {writeResult.Tag.Epc.ToHexString()} complete. Status: {writeResult.Result}");
                    }
                }
            }
        }
    }
}
