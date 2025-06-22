using System;
using System.IO;

namespace SingletonPatternExample
{
    /// <summary>
    /// Thread-safe Singleton Logger class for application-wide logging
    /// </summary>
    public sealed class Logger
    {
        // Static instance holder
        private static Logger _instance;

        // Thread synchronization object
        private static readonly object _syncLock = new object();

        // Log file path
        private readonly string _logPath;

        // Instance creation counter for verification
        private static int _creationCount = 0;

        /// <summary>
        /// Private constructor to prevent external instantiation
        /// </summary>
        private Logger()
        {
            _creationCount++;

            // Set log file path in application directory
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            // Create logs directory if it doesn't exist
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Create log file with timestamp
            string logFileName = $"AppLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            _logPath = Path.Combine(logDirectory, logFileName);

            // Write initialization message
            WriteLogEntry("SYSTEM", "Logger instance initialized successfully");
            Console.WriteLine($"Logger #{_creationCount} created - Log file: {_logPath}");
        }

        /// <summary>
        /// Gets the singleton instance of Logger (Thread-safe)
        /// </summary>
        public static Logger Instance
        {
            get
            {
                // Double-checked locking pattern for thread safety
                if (_instance == null)
                {
                    lock (_syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Logs an informational message
        /// </summary>
        public void LogInformation(string message)
        {
            WriteLogEntry("INFO", message);
            WriteToConsole(message, ConsoleColor.Cyan);
        }

        /// <summary>
        /// Logs a warning message
        /// </summary>
        public void LogWarning(string message)
        {
            WriteLogEntry("WARN", message);
            WriteToConsole(message, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Logs an error message
        /// </summary>
        public void LogError(string message)
        {
            WriteLogEntry("ERROR", message);
            WriteToConsole(message, ConsoleColor.Red);
        }

        /// <summary>
        /// Logs a debug message
        /// </summary>
        public void LogDebug(string message)
        {
            WriteLogEntry("DEBUG", message);
            WriteToConsole(message, ConsoleColor.Gray);
        }

        /// <summary>
        /// Gets detailed information about this logger instance
        /// </summary>
        public string GetInstanceInfo()
        {
            return $"Logger Instance - HashCode: {GetHashCode()}, " +
                   $"Thread: {System.Threading.Thread.CurrentThread.ManagedThreadId}, " +
                   $"Created: {_creationCount} time(s), " +
                   $"LogFile: {Path.GetFileName(_logPath)}";
        }

        /// <summary>
        /// Gets the current log file path
        /// </summary>
        public string GetLogFilePath()
        {
            return _logPath;
        }

        // Private helper methods
        private void WriteLogEntry(string level, string message)
        {
            try
            {
                string logEntry = FormatLogMessage(level, message);

                // Write to file with proper locking
                lock (_syncLock)
                {
                    File.AppendAllText(_logPath, logEntry + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }

        private string FormatLogMessage(string level, string message)
        {
            return $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] " +
                   $"[{level.PadRight(5)}] " +
                   $"[Thread-{System.Threading.Thread.CurrentThread.ManagedThreadId:D2}] " +
                   $"{message}";
        }

        private void WriteToConsole(string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine($"[LOG] {message}");
            Console.ForegroundColor = originalColor;
        }
    }
}
