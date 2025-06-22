using System;
using System.Threading.Tasks;

namespace SingletonPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SINGLETON LOGGER DEMONSTRATION ===\n");

            // Test 1: Basic singleton functionality
            TestSingletonBehavior();

            // Test 2: Different log levels
            TestLogLevels();

            // Test 3: Multi-threading test
            TestThreadSafety();

            // Test 4: Instance verification
            TestInstanceVerification();

            Console.WriteLine("\n=== TESTS COMPLETED ===");
            Console.WriteLine("Check the Logs folder for the log file!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void TestSingletonBehavior()
        {
            Console.WriteLine("TEST 1: Singleton Behavior");
            Console.WriteLine("-------------------------");

            Logger logger1 = Logger.Instance;
            logger1.LogInformation("First logger instance obtained");

            Logger logger2 = Logger.Instance;
            logger2.LogInformation("Second logger instance obtained");

            Console.WriteLine($"Instance 1: {logger1.GetInstanceInfo()}");
            Console.WriteLine($"Instance 2: {logger2.GetInstanceInfo()}");
            Console.WriteLine($"Same instance? {ReferenceEquals(logger1, logger2)}\n");
        }

        static void TestLogLevels()
        {
            Console.WriteLine("TEST 2: Different Log Levels");
            Console.WriteLine("----------------------------");

            Logger logger = Logger.Instance;
            logger.LogInformation("This is an information message");
            logger.LogWarning("This is a warning message");
            logger.LogError("This is an error message");
            logger.LogDebug("This is a debug message");
            Console.WriteLine();
        }

        static void TestThreadSafety()
        {
            Console.WriteLine("TEST 3: Thread Safety");
            Console.WriteLine("--------------------");

            Task[] tasks = new Task[3];

            for (int i = 0; i < 3; i++)
            {
                int taskId = i + 1;
                tasks[i] = Task.Run(() =>
                {
                    Logger logger = Logger.Instance;
                    logger.LogInformation($"Message from Task {taskId}");
                    Console.WriteLine($"Task {taskId}: {logger.GetInstanceInfo()}");
                });
            }

            Task.WaitAll(tasks);
            Console.WriteLine();
        }

        static void TestInstanceVerification()
        {
            Console.WriteLine("TEST 4: Instance Verification");
            Console.WriteLine("-----------------------------");

            Logger logger = Logger.Instance;
            Console.WriteLine($"Final Logger Details: {logger.GetInstanceInfo()}");
            Console.WriteLine($"Log File Location: {logger.GetLogFilePath()}");
        }
    }
}
