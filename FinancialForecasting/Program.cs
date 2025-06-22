using System;

namespace FinancialForecastingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    FINANCIAL FORECASTING TOOL                                ║");
            Console.WriteLine("║                     Recursive Algorithm Analysis                              ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════╝\n");

            try
            {
                // Demonstrate recursive concepts
                ExplainRecursionConcepts();

                // Create sample forecasting parameters
                var parameters = new ForecastingParameters(50000m, 0.12, 15)
                {
                    Volatility = 0.08,
                    InflationRate = 0.025,
                    PeriodType = "Monthly"
                };

                // Initialize forecaster
                var forecaster = new RecursiveForecaster();

                // Demonstrate different recursive approaches
                DemonstrateRecursiveApproaches(forecaster, parameters);

                // Perform comprehensive performance analysis
                var analyzer = new PerformanceAnalyzer();
                analyzer.PerformComprehensiveAnalysis();

                // Interactive forecasting demo
                PerformInteractiveForecasting();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Application Error: {ex.Message}");
            }

            Console.WriteLine("\n╔═══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                           ANALYSIS COMPLETE                                  ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void ExplainRecursionConcepts()
        {
            Console.WriteLine("🧠 UNDERSTANDING RECURSION IN FINANCIAL FORECASTING");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            Console.WriteLine("📖 RECURSION FUNDAMENTALS:");
            Console.WriteLine("   • Definition: A function that calls itself to solve smaller instances[1][11]");
            Console.WriteLine("   • Base Case: Simple condition that stops the recursion");
            Console.WriteLine("   • Recursive Case: Function calls itself with modified parameters");
            Console.WriteLine("   • Problem Decomposition: Breaking complex problems into simpler ones[3]");

            Console.WriteLine("\n💰 FINANCIAL APPLICATIONS:");
            Console.WriteLine("   • Compound Interest: Future value depends on previous value plus interest[7]");
            Console.WriteLine("   • Growth Projections: Each period builds upon the previous period");
            Console.WriteLine("   • Investment Valuations: Present value calculations using recursive discounting");
            Console.WriteLine("   • Loan Amortization: Monthly payments reduce principal recursively");

            Console.WriteLine("\n🔄 RECURSIVE FORMULA EXAMPLE:");
            Console.WriteLine("   Future Value Formula: FV(n) = FV(n-1) × (1 + growth_rate)");
            Console.WriteLine("   Base Case: FV(0) = Initial Investment");
            Console.WriteLine("   Recursive Case: Each period multiplies previous value by growth factor");

            Console.WriteLine("\n✅ ADVANTAGES OF RECURSIVE APPROACH:");
            Console.WriteLine("   • Natural modeling of time-dependent financial processes[2]");
            Console.WriteLine("   • Elegant and readable code for complex calculations[2]");
            Console.WriteLine("   • Easy to modify for different growth scenarios");
            Console.WriteLine("   • Handles variable growth rates naturally");
        }

        static void DemonstrateRecursiveApproaches(RecursiveForecaster forecaster, ForecastingParameters parameters)
        {
            Console.WriteLine("\n🎯 RECURSIVE FORECASTING DEMONSTRATIONS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            Console.WriteLine($"📊 Forecasting Parameters:");
            Console.WriteLine($"   Initial Investment: ${parameters.InitialValue:N2}");
            Console.WriteLine($"   Annual Growth Rate: {parameters.BaseGrowthRate:P2}");
            Console.WriteLine($"   Forecast Periods: {parameters.ForecastPeriods} months");
            Console.WriteLine($"   Volatility: {parameters.Volatility:P2}");
            Console.WriteLine($"   Inflation Rate: {parameters.InflationRate:P2}");

            // Demonstrate basic recursive approach
            Console.WriteLine("\n" + new string('═', 79));
            var basicResult = forecaster.BasicRecursiveForecast(parameters);
            basicResult.DisplayResults();

            // Demonstrate memoized approach
            Console.WriteLine("\n" + new string('═', 79));
            var memoResult = forecaster.MemoizedRecursiveForecast(parameters);
            memoResult.DisplayResults();

            // Demonstrate advanced approach
            Console.WriteLine("\n" + new string('═', 79));
            var advancedResult = forecaster.AdvancedRecursiveForecast(parameters);
            advancedResult.DisplayResults();
        }

        static void PerformInteractiveForecasting()
        {
            Console.WriteLine("\n🎮 INTERACTIVE FORECASTING DEMONSTRATION");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            var scenarios = new[]
            {
                new { Name = "Conservative Growth", InitialValue = 25000m, GrowthRate = 0.06, Periods = 12, Volatility = 0.02 },
                new { Name = "Moderate Growth", InitialValue = 50000m, GrowthRate = 0.10, Periods = 18, Volatility = 0.05 },
                new { Name = "Aggressive Growth", InitialValue = 100000m, GrowthRate = 0.15, Periods = 24, Volatility = 0.10 }
            };

            var forecaster = new RecursiveForecaster();

            foreach (var scenario in scenarios)
            {
                Console.WriteLine($"\n📈 SCENARIO: {scenario.Name}");
                Console.WriteLine(new string('─', 50));

                var parameters = new ForecastingParameters(scenario.InitialValue, scenario.GrowthRate, scenario.Periods)
                {
                    Volatility = scenario.Volatility,
                    InflationRate = 0.025
                };

                var result = forecaster.MemoizedRecursiveForecast(parameters);

                // Display summary
                if (result.ForecastedValues.Count > 0)
                {
                    var initialValue = result.ForecastedValues[0].Value;
                    var finalValue = result.ForecastedValues[result.ForecastedValues.Count - 1].Value;
                    var totalReturn = ((double)(finalValue - initialValue) / (double)initialValue) * 100;

                    Console.WriteLine($"   Initial: ${initialValue:N2} → Final: ${finalValue:N2}");
                    Console.WriteLine($"   Total Return: {totalReturn:F1}% over {scenario.Periods} periods");
                    Console.WriteLine($"   Efficiency: {result.RecursiveCalls} calls in {result.ComputationTime.TotalMilliseconds:F2}ms");
                }
            }
        }
    }
}
