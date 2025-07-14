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
        private readonly HashSet<string> _firstSeenEpcs = new HashSet<string>();
        private readonly object _epcLock = new object();

        public Form1()
        {
            InitializeComponent();
            FileConsole.Initialize("RaceLog.txt");
            // Initialize the time label display
            timeInputTextBox.Text = "00:00";
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
                    // If Add() returns true, it means the EPC was NOT already in the set,
                    // so this is the first time we've encountered it.
                    if (_firstSeenEpcs.Add(tag.Epc.ToString()))
                    {
                        this.Invoke((MethodInvoker)(() => resultslistBox.Items.Add(timeInputTextBox.Text + tag.Epc)));
                    }
                    FileConsole.WriteLine("{0}, {1}, {2}, {3}",
                                            tag.Epc,
                                            timeInputTextBox.Text,
                                            tag.FirstSeenTime.LocalDateTime,
                                            tag.LastSeenTime.LocalDateTime);
                }
            }
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
            catch (FormatException)
            {

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
            if (reader.QueryStatus().IsSingulating)
            {
                reader.Stop();
                // Disconnect from the reader.
                reader.Disconnect();
            }

            FileConsole.WriteLine("Application is closing. Shutting down FileFileConsole.");
            FileConsole.Close();
        }

        private void removeTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if any items are selected
            if (resultslistBox.SelectedItems.Count > 0)
            {
                // Create a temporary list to hold the items to remove.
                // This is crucial because modifying the original collection while iterating
                // over it (myListBox.SelectedItems) can lead to errors.
                List<object> itemsToRemove = new List<object>();

                foreach (object selectedItem in resultslistBox.SelectedItems)
                {
                    itemsToRemove.Add(selectedItem);
                }

                // Prepare the confirmation message
                string confirmationMessage;
                if (itemsToRemove.Count == 1)
                {
                    confirmationMessage = $"Are you sure you want to remove '{itemsToRemove[0].ToString()}'?";
                }
                else
                {
                    confirmationMessage = $"Are you sure you want to remove {itemsToRemove.Count} selected items?";
                }

                // Display a confirmation message before removing
                DialogResult confirmResult = MessageBox.Show(
                    confirmationMessage,
                    "Confirm Removal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // Now, safely remove each item from the ListBox's Items collection
                    foreach (object item in itemsToRemove)
                    {
                        resultslistBox.Items.Remove(item);
                        _ = _firstSeenEpcs.Add(GetStringAfterFirstSpace(item.ToString()));
                    }
                    MessageBox.Show($"{itemsToRemove.Count} item(s) removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public static string GetStringAfterFirstSpace(string input)
        {
            // Check if the input string is null or empty to prevent errors
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty; // Or return null, depending on desired behavior for empty/null input
            }

            // Find the index of the first space
            int firstSpaceIndex = input.IndexOf(' ');

            // If a space is found and it's not the last character
            if (firstSpaceIndex >= 0 && firstSpaceIndex < input.Length - 1)
            {
                // Return the substring starting from the character *after* the first space
                return input.Substring(firstSpaceIndex + 1);
            }
            else
            {
                // If no space is found, or the space is the very last character,
                // there's nothing after the first space, so return an empty string or the original string.
                // Returning empty string is common for "everything after".
                return string.Empty;
            }
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                settings.Antennas.GetAntenna(1).TxPowerInDbm = (double)numericPower.Value;
                settings.Antennas.GetAntenna(1).RxSensitivityInDbm = (double)numericSensitivity.Value;
                settings.Antennas.GetAntenna(2).TxPowerInDbm = (double)numericPower.Value;
                settings.Antennas.GetAntenna(2).RxSensitivityInDbm = (double)numericSensitivity.Value;
                settings.Report.IncludeFirstSeenTime = true;
                settings.Report.IncludeLastSeenTime = true;

                // Send a tag report for every tag read.
                settings.Report.Mode = ReportMode.Individual;

                // Apply the newly modified settings.
                reader.ApplySettings(settings);

                // Assign the TagsReported event handler.
                // This specifies which method to call
                // when tags reports are available.
                reader.TagsReported += OnTagsReported;

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
        }

        private void resultslistBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Check for Ctrl+C combination
            if (e.Control && e.KeyCode == Keys.C)
            {
                // Ensure there are selected items to copy
                if (resultslistBox.SelectedItems.Count > 0)
                {
                    // Use StringBuilder for efficient string concatenation, especially for many items
                    StringBuilder sb = new StringBuilder();

                    // Iterate through all selected items
                    foreach (object item in resultslistBox.SelectedItems)
                    {
                        sb.AppendLine(item.ToString()); // Add each item's text, followed by a newline
                    }

                    // Copy the combined text to the clipboard
                    Clipboard.SetText(sb.ToString());

                    // Optionally, provide user feedback
                    //MessageBox.Show($"{resultslistBox.SelectedItems.Count} item(s) copied to clipboard.", "Copy Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Prevent the default handling of Ctrl+C (e.g., if another control has it)
                    e.Handled = true;
                }
            }
        }
    }
}
    
