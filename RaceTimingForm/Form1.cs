using Impinj.OctaneSdk;
using System.Diagnostics;
using System.Media;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RaceTimingForm
{
    public partial class Form1 : Form
    {
        // Declare a Stopwatch object
        private Stopwatch stopwatch = new Stopwatch();
        // Parse user input (e.g., "01:00:00" for 1 hour)
        private TimeSpan _offsetTime = TimeSpan.Zero; // This will store your "set" value or accumulated paused time

        static ImpinjReader reader = new ImpinjReader();
        private readonly object _epcLock = new object();
        private static readonly object lockObject = new object();
        private static Dictionary<string, Tag> _firstSeenEpcs = new Dictionary<string, Tag>();

        public Form1()
        {
            InitializeComponent();
            FileConsole.Initialize("RaceLog.txt");
            // Initialize the time label display
            timeInputTextBox.Text = "00:00";
        }

        // You might also want a way to clear _firstSeenEpcs if you want to reset the "first seen" status,
        // e.g., for a new batch of items or at the start of a new operation.
        public void ClearFirstSeenTags()
        {
            lock (_epcLock)
            {
                _firstSeenEpcs.Clear();
                FileConsole.WriteLine("Cleared all first-seen tag records.");
            }
        }

        // Event handler for the Start button click
        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                _offsetTime = TimeSpan.ParseExact(timeInputTextBox.Text, "mm\\:ss", null);
            }
            catch (FormatException ex)
            {
                FileConsole.WriteLine("Invalid time format: {0}", ex.Message);
                _offsetTime = TimeSpan.Zero;
            }

            stopwatch.Start(); // Start the Stopwatch
            updateTimer.Start(); // Start the UI update timer
            // Optionally disable/enable buttons for better user experience
            startButton.Enabled = false;
            stopButton.Enabled = true;
            resetButton.Enabled = true;
            FileConsole.WriteLine("Stopwatch started:  {0}", timeInputTextBox.Text);
        }

        // Event handler for the Stop button click
        private void stopButton_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();   // Stop the Stopwatch
            updateTimer.Stop(); // Stop the UI update timer
            // Optionally disable/enable buttons
            startButton.Enabled = true; // Can resume from where it left off
            stopButton.Enabled = false;
            resetButton.Enabled = true;
            FileConsole.WriteLine("Stopwatch stopped:  {0}", timeInputTextBox.Text);
        }

        // Event handler for the Reset button click
        private void resetButton_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();  // Reset the Stopwatch to zero
            updateTimer.Stop(); // Stop the UI update timer (if it's running)
            timeInputTextBox.Text = "00:00"; // Reset display to zero
            _offsetTime = TimeSpan.Zero;
            // Reset button states
            startButton.Enabled = true;
            stopButton.Enabled = false;
            resetButton.Enabled = false; // Disable reset if time is 0
            clearAllToolStripMenuItem_Click(sender, e);
            FileConsole.WriteLine("Stopwatch reset.");
        }


        // Optional: Form Load event to set initial button states
        private void Form1_Load(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            resetButton.Enabled = false;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            // Update the label with the current elapsed time from the Stopwatch
            // TimeSpan provides a convenient way to format the time
            TimeSpan ts = stopwatch.Elapsed.Add(_offsetTime);

            // Format as HH:MM:SS.FFF (Hours:Minutes:Seconds.Milliseconds)
            // {0:00} means format with leading zeros if single digit
            timeInputTextBox.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                                            ts.Hours,
                                            ts.Minutes,
                                            ts.Seconds,
                                            ts.Milliseconds);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Don't call the Stop method if the
            // reader is already stopped.
            try
            {
                if (reader.IsConnected && reader.QueryStatus().IsSingulating)
                {
                    reader.Stop();
                    // Disconnect from the reader.
                    reader.Disconnect();
                }

            }
            catch (Exception)
            {
                throw;
            }

            FileConsole.WriteLine("Application is closing. Shutting down FileFileConsole.");
            SaveResults();
        }
        private void SaveResults()
        {
            string timestamp = DateTime.Now.ToString("HHmmssfff");
            string fPath = "results_" + timestamp + ".txt";
            using (StreamWriter sw = new StreamWriter(fPath))
            {
                foreach (object item in resultslistBox.Items)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }

        private void removeTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resultslistBox.SelectedItems.Count > 0)
            {
                List<object> itemsToRemove = new List<object>(resultslistBox.SelectedItems.Cast<object>());
                string confirmationMessage = itemsToRemove.Count == 1
                    ? $"Are you sure you want to remove '{itemsToRemove[0]}'?"
                    : $"Are you sure you want to remove {itemsToRemove.Count} selected items?";

                DialogResult confirmResult = MessageBox.Show(
                    confirmationMessage,
                    "Confirm Removal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    RemoveSelectedItemsFromListBox(resultslistBox);
                    MessageBox.Show($"{itemsToRemove.Count} item(s) removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void RemoveSelectedItemsFromListBox(ListBox listBox)
        {
            List<object> itemsToRemove = new List<object>(listBox.SelectedItems.Cast<object>());
            foreach (object item in itemsToRemove)
            {
                listBox.Items.Remove(item);
                if (item is TagListBoxItem i && _firstSeenEpcs.ContainsKey(i.Tag))
                    _ = _firstSeenEpcs.Remove(i.Tag);
            }
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveResults();

            // Prepare the confirmation message
            string confirmationMessage;
            confirmationMessage = $"Are you sure you want to remove {resultslistBox.Items.Count} items?";

            // Display a confirmation message before removing
            DialogResult confirmResult = MessageBox.Show(
                confirmationMessage,
                "Confirm Removal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            
            if (confirmResult == DialogResult.Yes)
            {
                resultslistBox.Items.Clear();
                _firstSeenEpcs.Clear();
                dataGridView.Rows.Clear();

                MessageBox.Show($"All items removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void connectButton_Click(object sender, EventArgs evt)
        {
            try
            {
                string hostname = "SpeedwayR-16-50-19";
                reader.Connect(hostname);

                // Get the default settings
                // We'll use these as a starting point
                // and then modify the settings we're 
                // interested in.

                Settings settings = reader.QueryDefaultSettings();

                if (radioButton1.Checked)
                {

                    // Tell the reader to include the antenna number
                    // in all tag reports. Other fields can be added
                    // to the reports in the same way by setting the 
                    // appropriate Report.IncludeXXXXXXX property.
                    settings.Report.IncludeAntennaPortNumber = true;

                    // The reader can be set into various modes in which reader
                    // dynamics are optimized for specific regions and environments.
                    // The following mode, AutoSetDenseReaderDeepScan (1002), monitors RF noise
                    // and interference then automatically and continuously optimizes
                    // the reader�s configuration
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
                    settings.Antennas.GetAntenna(1).TxPowerInDbm = (double)numericPower.Value;
                    settings.Antennas.GetAntenna(1).RxSensitivityInDbm = (double)numericSensitivity.Value;
                    settings.Antennas.GetAntenna(2).TxPowerInDbm = (double)numericPower.Value;
                    settings.Antennas.GetAntenna(2).RxSensitivityInDbm = (double)numericSensitivity.Value;
                    settings.Report.IncludeFirstSeenTime = true;
                    settings.Report.IncludeLastSeenTime = true;

                    // Send a tag report for every tag read.
                    settings.Report.Mode = ReportMode.Individual;
                }
                if (radioButton2.Checked)
                {

                    settings.Report.IncludeAntennaPortNumber = true;
                    settings.Report.IncludePeakRssi = true;
                    settings.Report.IncludePcBits = true; // Essential for correct EPC writing
                    settings.Report.IncludeFirstSeenTime = true;
                    settings.Report.IncludeLastSeenTime = true;

                    // Set reader mode for good performance
                    settings.ReaderMode = ReaderMode.AutoSetDenseReader;

                    // Enable one antenna
                    settings.Antennas.DisableAll();
                    for (ushort i = 1; i <= 1; i++) // Let's program with only 1 (up to 4 antennas)
                    {
                        settings.Antennas.GetAntenna(i).IsEnabled = true;
                        settings.Antennas.GetAntenna(i).TxPowerInDbm = 24; //  30 =Max power (adjust as needed)
                        settings.Antennas.GetAntenna(i).RxSensitivityInDbm = -70; // Good sensitivity (adjust as needed)
                    }
                }
                // Apply the newly modified settings.
                reader.ApplySettings(settings);

                // Assign the TagsReported event handler.
                // This specifies which method to call
                // when tags reports are available.
                reader.TagsReported += OnTagsReported;
                reader.TagOpComplete += OnTagOpComplete;


                // Don't call the Start method if the
                // reader is already running.
                if (!reader.QueryStatus().IsSingulating)
                {
                    // Start reading.
                    reader.Start();
                }
                startButton.Enabled = true;
                connectButton.Enabled = false;
                numericPower.Enabled = false;
                numericSensitivity.Enabled = false;
                debugTextbox.Visible = false;
                addButton.Visible = false;
            }
            catch (OctaneSdkException e)
            {
                // Handle Octane SDK errors.
                FileConsole.WriteLine(e.Message);
                errorLabel.Text = e.Message;
            }
            catch (Exception e)
            {
                // Handle other .NET errors.
                FileConsole.WriteLine(e.Message);
                errorLabel.Text = e.Message;

            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            resultslistBox.Items.Add(timeInputTextBox.Text + debugTextbox.Text);
            dataGridView.Rows.Add(debugTextbox.Text);
            if (checkBeep.Checked)
                Console.Beep(500, 25); // Beep to indicate a new tag was found

        }

        private void resultslistBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Use StringBuilder for efficient string concatenation, especially for many items

            // Check for Ctrl+C combination
            if (e.Control && e.KeyCode == Keys.C)
            {
                StringBuilder sb = new StringBuilder();
               
                foreach (object item in resultslistBox.Items)
                {
                    sb.AppendLine(item.ToString());
                }

                // Copy the combined text to the clipboard
                Clipboard.SetText(sb.ToString());

                // Prevent the default handling of Ctrl+C (e.g., if another control has it)
                e.Handled = true;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.V))
            {
                PasteFromClipboard();
                return true; // Indicate that we've handled the key press
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PasteFromClipboard()
        {
            try
            {
                string clipboardText = Clipboard.GetText();
                if (string.IsNullOrEmpty(clipboardText))
                {
                    return;
                }

                string[] rows = clipboardText.Split('\n');
                int currentRowIndex = 0;
                int currentColIndex = 1;

                if (dataGridView.CurrentCell != null)
                {
                    currentColIndex = dataGridView.CurrentCell.ColumnIndex;
                    currentRowIndex = dataGridView.CurrentCell.RowIndex;
                }

                foreach (string row in rows)
                {
                    if (string.IsNullOrEmpty(row.Trim()))
                    {
                        continue;
                    }

                    // Split by tab for columns
                    string[] cells = row.Split('\t');
                    for (int i = 0; i < cells.Length; i++)
                    {
                        if (currentColIndex + i < dataGridView.Columns.Count)
                        {
                            // Ensure enough rows exist to paste into
                            if (currentRowIndex >= dataGridView.Rows.Count - 1)
                            {
                                dataGridView.Rows.Add();
                            }
                            dataGridView.Rows[currentRowIndex].Cells[currentColIndex + i].Value = cells[i];
                        }
                    }
                    currentRowIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to paste data: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonWrite.Enabled = true;

            int startNum = int.Parse(textFirstNum.Text);
            for (int row = 0; row < dataGridView.Rows.Count; row++)
            {
                dataGridView.Rows[row].Cells[1].Value = startNum++;
            }
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < dataGridView.Rows.Count; row++)
            {
                if (dataGridView.Rows[row].Cells[1].Value != null)
                {
                    String origEPC = dataGridView.Rows[row].Cells[0].Value.ToString();
                    String newEPC = dataGridView.Rows[row].Cells[1].Value.ToString();

                    string newEpcHexString;
                    lock (lockObject)
                    {
                        newEpcHexString = FormatEpcHexString(newEPC);
                    }

                    //Console.WriteLine($"Attempting to program tag {tag.Epc.ToHexString()} to new EPC: {newEpcHexString}...");

                    try
                    {
                        ProgramTagEpc(_firstSeenEpcs[origEPC].Epc.ToHexString(), _firstSeenEpcs[origEPC], newEpcHexString);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error scheduling write for tag {origEPC}: {ex.Message}");
                    }
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
            ushort newPcBits = PcBits.AdjustPcBits(currentTag.PcBits, newEpcLenWords);

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
        }
        void OnTagsReported(ImpinjReader sender, TagReport report)
        {
            foreach (Tag tag in report)
            {
                // Use a lock to ensure thread safety when accessing the HashSet
                // This is crucial because OnTagsReported is called asynchronously
                // and multiple reports might arrive concurrently.
                lock (_epcLock)
                {
                    // Try to add the EPC to our set.
                    // if this is the first time we've encountered it.
                    string t = tag.Epc.ToString();
                    t = t.Substring(t.Length - (t.Length > 3 ? 3 : 0));

                    if (!_firstSeenEpcs.ContainsKey(tag.Epc.ToString()))
                    {
                        _firstSeenEpcs[tag.Epc.ToString()] = tag;

                        var item = new TagListBoxItem { DisplayText = timeInputTextBox.Text + "\t" + t, Tag = tag.Epc.ToString() };
                        this.Invoke((MethodInvoker)(() => resultslistBox.Items.Add(item)));
                        this.Invoke((MethodInvoker)(() => dataGridView.Rows.Insert(0,tag.Epc.ToString())));
                        if(checkBeep.Checked)
                            Console.Beep(500, 20); // Beep to indicate a new tag was found

                    }
                    this.Invoke((MethodInvoker)(() => rawListBox.Items.Insert(0, t)));

                    FileConsole.WriteLine("{0}, {1}, {2}, {3}",
                                            tag.Epc,
                                            timeInputTextBox.Text,
                                            tag.FirstSeenTime.LocalDateTime,
                                            tag.LastSeenTime.LocalDateTime);
                }
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
                        }
                        else
                        {
                            Console.WriteLine($"  -> Failed to program tag {writeResult.Tag.Epc.ToHexString()}. Status: {writeResult.Result}");
                            // If a write fails, remove from programmedEpcs so it can be reattempted
                            lock (lockObject)
                            {
                                //programmedEpcs.Remove(writeResult.Tag.Epc.ToHexString());
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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= 0 && e.ColumnIndex == 1)
                dataGridView.BeginEdit(true);
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            
            if (dataGridView.Rows[row].Cells[1].Value != null)
            {
                String origEPC = dataGridView.Rows[row].Cells[0].Value.ToString();
                String newEPC = dataGridView.Rows[row].Cells[1].Value.ToString();

                string newEpcHexString;
                lock (lockObject)
                {
                    newEpcHexString = FormatEpcHexString(newEPC);
                }

                //Console.WriteLine($"Attempting to program tag {tag.Epc.ToHexString()} to new EPC: {newEpcHexString}...");

                try
                {
                    ProgramTagEpc(_firstSeenEpcs[origEPC].Epc.ToHexString(), _firstSeenEpcs[origEPC], newEpcHexString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error scheduling write for tag {origEPC}: {ex.Message}");
                }
            }
        }

        private static string FormatEpcHexString(string newEPC)
        {
            int value = Convert.ToInt32(newEPC, 16);
            string newEpcHexString = $"30000000000000000000{value:X12}";
            return newEpcHexString.Substring(newEpcHexString.Length - 24);
        }
    }
    public class TagListBoxItem
    {
        public string DisplayText { get; set; }
        public string Tag { get; set; }
        public override string ToString()
        {
            return DisplayText;
        }
    }

}