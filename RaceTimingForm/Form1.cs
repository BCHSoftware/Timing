using System.Diagnostics;
using Impinj.OctaneSdk;
using System.Media;

namespace RaceTimingForm
{
    public partial class Form1 : Form
    {
        // Declare a Stopwatch object
        private Stopwatch stopwatch = new Stopwatch();
        static ImpinjReader reader = new ImpinjReader();
        private readonly HashSet<string> _firstSeenEpcs = new HashSet<string>();
        private readonly object _epcLock = new object();

        public Form1()
        {
            InitializeComponent();
            FileConsole.Initialize("RaceLog.txt");
            // Initialize the time label display
            timeLabel.Text = "00:00:00.000";

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
                        // Log only if it's a new EPC
                        FileConsole.WriteLine("FIRST SEEN Tag: Antenna : {0}, EPC : {1}, First : {2}, Last : {3}",
                                              tag.AntennaPortNumber,
                                              tag.Epc,
                                              tag.FirstSeenTime.LocalDateTime,
                                              tag.LastSeenTime.LocalDateTime);
                    }
                    else
                    {
                         FileConsole.WriteLine($"DEBUG: Existing tag {tag.Epc} re-read.");
                    }
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
            stopwatch.Start(); // Start the Stopwatch
            updateTimer.Start(); // Start the UI update timer
            // Optionally disable/enable buttons for better user experience
            startButton.Enabled = false;
            stopButton.Enabled = true;
            resetButton.Enabled = true;
            FileConsole.WriteLine("Stopwatch started:  {0}", timeLabel.Text);
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
            FileConsole.WriteLine("Stopwatch stopped:  {0}", timeLabel.Text);
        }

        // Event handler for the Reset button click
        private void resetButton_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();  // Reset the Stopwatch to zero
            updateTimer.Stop(); // Stop the UI update timer (if it's running)
            timeLabel.Text = "00:00:00.000"; // Reset display to zero
            // Reset button states
            startButton.Enabled = true;
            stopButton.Enabled = false;
            resetButton.Enabled = false; // Disable reset if time is 0
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
            TimeSpan ts = stopwatch.Elapsed;

            // Format as HH:MM:SS.FFF (Hours:Minutes:Seconds.Milliseconds)
            // {0:00} means format with leading zeros if single digit
            timeLabel.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                                            ts.Hours,
                                            ts.Minutes,
                                            ts.Seconds,
                                            ts.Milliseconds);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop reading.
            reader.Stop();

            // Disconnect from the reader.
            reader.Disconnect();

            FileConsole.WriteLine("Application is closing. Shutting down FileFileConsole.");
            FileConsole.Close();
        }
    }
}
