////////////////////////////////////////////////////////////////////////////////
//
//    Read Tags
//
////////////////////////////////////////////////////////////////////////////////

using System;
using Impinj.OctaneSdk;
using System.IO;

namespace OctaneSdkExamples
{
    class Program
    {
        // Create an instance of the ImpinjReader class.
        static ImpinjReader reader = new ImpinjReader();

        static void Main(string[] args)
        {
            try
            {
                // Connect to the reader.
                // Pass in a reader hostname or IP address as a 
                // command line argument when running the example
                if (args.Length != 1)
                {
                    Console.WriteLine("Error: No hostname specified.  Pass in the reader hostname as a command line argument when running the Sdk Example.");
                    return;
                }
                string hostname = args[0];
                reader.Connect(hostname);

                // Get the default settings
                // We'll use these as a starting point
                // and then modify the settings we're 
                // interested in.

                Settings settings = reader.QueryDefaultSettings();

                // Tell the reader to include the antenna number
                // in all tag reports. Other fields can be added
                // to the reports in the same way by setting the 
                // appropriate Report.IncludeXXXXXXX property.
                settings.Report.IncludeAntennaPortNumber = true;

                // The reader can be set into various modes in which reader
                // dynamics are optimized for specific regions and environments.
                // The following mode, AutoSetDenseReaderDeepScan (1002), monitors RF noise
                // and interference then automatically and continuously optimizes
                // the reader’s configuration
                settings.RfMode = 1002;
                settings.SearchMode = SearchMode.DualTarget;
                settings.Session = 2;

                // Disable all antennas.
                settings.Antennas.DisableAll();
                // Enable antenna #1. Disable all others.
                settings.Antennas.GetAntenna(1).IsEnabled = true;
                // Enable antenna #2. Disable all others.
                settings.Antennas.GetAntenna(2).IsEnabled = true;

                // Set the Transmit Power and 
                // You can also set them to specific values like this...
                settings.Antennas.GetAntenna(1).TxPowerInDbm = 10;
                settings.Antennas.GetAntenna(1).RxSensitivityInDbm = -80;
                settings.Antennas.GetAntenna(2).TxPowerInDbm = 10;
                settings.Antennas.GetAntenna(2).RxSensitivityInDbm = -80;
                settings.Report.IncludeFirstSeenTime = true;
                settings.Report.IncludeLastSeenTime = true;

                // Apply the newly modified settings.
                reader.ApplySettings(settings);

                // Assign the TagsReported event handler.
                // This specifies which method to call
                // when tags reports are available.
                reader.TagsReported += OnTagsReported;

                // Start reading.
                reader.Start();

                // Wait for the user to press enter.
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();

                // Stop reading.
                reader.Stop();

                // Disconnect from the reader.
                reader.Disconnect();
            }
            catch (OctaneSdkException e)
            {
                // Handle Octane SDK errors.
                Console.WriteLine("Octane SDK exception: {0}", e.Message);
            }
            catch (Exception e)
            {
                // Handle other .NET errors.
                Console.WriteLine("Exception : {0}", e.Message);
            }
        }

        static void OnTagsReported(ImpinjReader sender, TagReport report)
        {
            // This event handler is called asynchronously 
            // when tag reports are available.
            // Default test for ReadTags 
            // Loop through each tag in the report 
            // and print the data.
            foreach (Tag tag in report)
            {
                Console.WriteLine("Antenna : {0}, EPC : {1} First : {2} Last : {3}",
                                tag.AntennaPortNumber, tag.Epc, tag.FirstSeenTime.LocalDateTime, tag.LastSeenTime.LocalDateTime);
                if (tag.FirstSeenTime.LocalDateTime == tag.LastSeenTime.LocalDateTime)
                    Console.Beep();
             /*   // Create a string array with the lines of text
                string[] lines = { "First line", "Second line", "Third line" };

                // Set a variable to the Documents path.
                string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
                Console.WriteLine(tag.FirstSeenTime);
            */}
        }
    }
}
