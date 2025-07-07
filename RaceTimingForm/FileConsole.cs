using System;
using System.IO;
using System.Threading; // For locking

public static class FileConsole
{
    private static StreamWriter? _writer;
    private static string? _filePath;
    private static bool _isInitialized = false;
    private static readonly object _lockObject = new object(); // For thread safety

    /// <summary>
    /// Initializes the FileConsole to write to a specified file.
    /// If the file exists, it will append to it.
    /// </summary>
    /// <param name="filePath">The full path to the log file.</param>
    /// <exception cref="ArgumentNullException">Thrown if filePath is null or empty.</exception>
    /// <exception cref="IOException">Thrown if the file cannot be opened for writing.</exception>
    public static void Initialize(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");
        }

        lock (_lockObject)
        {
            if (_isInitialized)
            {
                // Optionally close existing writer before re-initializing
                Close();
            }

            _filePath = filePath;
            try
            {
                // Create a StreamWriter to write to the file, append if it exists
                _writer = new StreamWriter(_filePath, append: true)
                {
                    AutoFlush = true // Ensures data is written to file immediately
                };
                _isInitialized = true;
            }
            catch (IOException ex)
            {
                // Log the error to the actual Console or throw
                Console.Error.WriteLine($"Error initializing FileConsole: {ex.Message}");
                throw; // Re-throw to inform the caller that initialization failed
            }
        }
    }

    /// <summary>
    /// Writes the specified string value to the file without a newline.
    /// Automatically prepends a timestamp.
    /// </summary>
    /// <param name="value">The string value to write.</param>
    public static void Write(string value)
    {
        if (!_isInitialized)
        {
            Console.Error.WriteLine("FileConsole not initialized. Call Initialize() first.");
            return;
        }

        lock (_lockObject)
        {
            try
            {
                _writer.Write(value);
            }
            catch (ObjectDisposedException)
            {
                Console.Error.WriteLine("FileConsole writer is disposed. Reinitialize if needed.");
                _isInitialized = false; // Mark as uninitialized
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"Error writing to file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An unexpected error occurred during FileConsole.Write: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Writes the specified string value to the file, followed by a newline.
    /// Automatically prepends a timestamp.
    /// </summary>
    /// <param name="value">The string value to write.</param>
    public static void WriteLine(string value)
    {
        if (!_isInitialized)
        {
            Console.Error.WriteLine("FileConsole not initialized. Call Initialize() first.");
            return;
        }

        lock (_lockObject)
        {
            try
            {
                _writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} {value}");
            }
            catch (ObjectDisposedException)
            {
                Console.Error.WriteLine("FileConsole writer is disposed. Reinitialize if needed.");
                _isInitialized = false; // Mark as uninitialized
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"Error writing line to file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An unexpected error occurred during FileConsole.WriteLine: {ex.Message}");
            }
        }
    }

    // --- Overloads for common data types ---

    public static void Write(int value) => Write(value.ToString());
    public static void Write(double value) => Write(value.ToString());
    public static void Write(bool value) => Write(value.ToString());
    public static void Write(object value) => Write(value?.ToString() ?? ""); // Handle null objects
    public static void Write(char value) => Write(value.ToString());
    public static void Write(char[] buffer) => Write(new string(buffer));
    public static void Write(char[] buffer, int index, int count) => Write(new string(buffer, index, count));

    public static void WriteLine() => WriteLine(""); // Just a newline
    public static void WriteLine(int value) => WriteLine(value.ToString());
    public static void WriteLine(double value) => WriteLine(value.ToString());
    public static void WriteLine(bool value) => WriteLine(value.ToString());
    public static void WriteLine(object value) => WriteLine(value?.ToString() ?? "");
    public static void WriteLine(char value) => WriteLine(value.ToString());
    public static void WriteLine(char[] buffer) => WriteLine(new string(buffer));
    public static void WriteLine(char[] buffer, int index, int count) => WriteLine(new string(buffer, index, count));

    // For writing without a newline (like Console.Write())
    public static void Write(string format, params object[] args)
    {
        Write(string.Format(format, args));
    }

    // For writing with a newline and timestamp (like Console.WriteLine())
    public static void WriteLine(string format, params object[] args)
    {
        // The timestamp is added by the base WriteLine(string value) method
        WriteLine(string.Format(format, args));
    }
    /// <summary>
    /// Closes the underlying file stream, releasing file resources.
    /// This should be called when your application is shutting down.
    /// </summary>
    public static void Close()
    {
        lock (_lockObject)
        {
            if (_writer != null)
            {
                try
                {
                    _writer.Close(); // Close the stream
                    _writer.Dispose(); // Dispose of the writer
                    _writer = null;
                    _isInitialized = false;
                }
                catch (IOException ex)
                {
                    Console.Error.WriteLine($"Error closing FileConsole: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"An unexpected error occurred during FileConsole.Close: {ex.Message}");
                }
            }
        }
    }
}