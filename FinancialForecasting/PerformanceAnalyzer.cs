using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FinancialForecastingTool
{
    /// <summary>
    /// Analyzes and compares performance of different recursive forecasting approaches
    /// Demonstrates time complexity analysis and optimization techniques
    /// </summary>
    public class PerformanceAnalyzer
    {
        /// <summary>
        /// Compares different recursive algorithms and their performance characteristics
        /// </summary>
        public void PerformComprehensiveAnalysis()
        {
            Console.WriteLine("📈 COMPREHENSIVE PERFORMANCE ANALYSIS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            var parameters = new ForecastingParameters(10000m, 0.08, 20)
            {
                Volatility = 0.05,
                InflationRate = 0.03
            };

            var forecaster = new RecursiveForecaster();
            var results = new List<ForecastResult>();

            // Test different algorithms
            Console.WriteLine("\n1️⃣ BASIC RECURSIVE ALGORITHM");
            Console.WriteLine("─────────────────────────────");
            results.Add(forecaster.BasicRecursiveForecast(parameters));

            Console.WriteLine("\n2️⃣ MEMOIZED RECURSIVE ALGORITHM");
            Console.WriteLine("────────────────────────────────");
            results.Add(forecaster.MemoizedRecursiveForecast(parameters));

            Console.WriteLine("\n3️⃣ TAIL-RECURSIVE ALGORITHM");
            Console.WriteLine("────────────────────────────");
            results.Add(forecaster.TailRecursiveForecast(parameters));

            Console.WriteLine("\n4️⃣ ADVANCED RECURSIVE ALGORITHM");
            Console.WriteLine("────────────────────────────────");
            results.Add(forecaster.AdvancedRecursiveForecast(parameters));

            // Display comparative analysis
            DisplayPerformanceComparison(results);

            // Analyze scalability
            AnalyzeScalability();

            // Provide optimization recommendations
            ProvideOptimizationRecommendations();
        }

        /// <summary>
        /// Displays detailed performance comparison between algorithms
        /// </summary>
        private void DisplayPerformanceComparison(List<ForecastResult> results)
        {
            Console.WriteLine("\n📊 PERFORMANCE COMPARISON");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            Console.WriteLine("┌─────────────────────────┬─────────────────┬─────────────────┬─────────────────┐");
            Console.WriteLine("│ Algorithm               │ Recursive Calls │ Time (ms)       │ Efficiency      │");
            Console.WriteLine("├─────────────────────────┼─────────────────┼─────────────────┼─────────────────┤");

            foreach (var result in results)
            {
                string efficiency = CalculateEfficiencyRating(result);
                Console.WriteLine($"│ {result.Algorithm,-23} │ {result.RecursiveCalls,15:N0} │ {result.ComputationTime.TotalMilliseconds,15:F2} │ {efficiency,-15} │");
            }

            Console.WriteLine("└─────────────────────────┴─────────────────┴─────────────────┴─────────────────┘");

            // Find best performing algorithm
            var fastest = results[0];
            var mostEfficient = results[0];

            foreach (var result in results)
            {
                if (result.ComputationTime < fastest.ComputationTime)
                    fastest = result;
                if (result.RecursiveCalls < mostEfficient.RecursiveCalls)
                    mostEfficient = result;
            }

            Console.WriteLine($"\n🏆 PERFORMANCE WINNERS:");
            Console.WriteLine($"   Fastest Execution: {fastest.Algorithm} ({fastest.ComputationTime.TotalMilliseconds:F2} ms)");
            Console.WriteLine($"   Most Efficient: {mostEfficient.Algorithm} ({mostEfficient.RecursiveCalls:N0} calls)");
        }

        /// <summary>
        /// Calculates efficiency rating based on recursive calls and time
        /// </summary>
        private string CalculateEfficiencyRating(ForecastResult result)
        {
            if (result.RecursiveCalls <= 50 && result.ComputationTime.TotalMilliseconds <= 10)
                return "Excellent";
            else if (result.RecursiveCalls <= 100 && result.ComputationTime.TotalMilliseconds <= 50)
                return "Good";
            else if (result.RecursiveCalls <= 200 && result.ComputationTime.TotalMilliseconds <= 100)
                return "Fair";
            else
                return "Poor";
        }

        /// <summary>
        /// Analyzes how algorithms scale with increasing input size
        /// </summary>
        private void AnalyzeScalability()
        {
            Console.WriteLine("\n📈 SCALABILITY ANALYSIS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            int[] testSizes = { 10, 20, 50, 100 };
            var forecaster = new RecursiveForecaster();

            Console.WriteLine("┌─────────────┬─────────────────────┬─────────────────────┬─────────────────────┐");
            Console.WriteLine("│ Periods     │ Basic Recursive     │ Memoized           │ Tail Recursive      │");
            Console.WriteLine("│             │ Calls    Time(ms)   │ Calls    Time(ms)   │ Calls    Time(ms)   │");
            Console.WriteLine("├─────────────┼─────────────────────┼─────────────────────┼─────────────────────┤");

            foreach (int size in testSizes)
            {
                var parameters = new ForecastingParameters(10000m, 0.08, size);

                var basicResult = forecaster.BasicRecursiveForecast(parameters);
                var memoResult = forecaster.MemoizedRecursiveForecast(parameters);
                var tailResult = forecaster.TailRecursiveForecast(parameters);

                Console.WriteLine($"│ {size,11} │ {basicResult.RecursiveCalls,8:N0} {basicResult.ComputationTime.TotalMilliseconds,10:F2} │ " +
                                $"{memoResult.RecursiveCalls,8:N0} {memoResult.ComputationTime.TotalMilliseconds,10:F2} │ " +
                                $"{tailResult.RecursiveCalls,8:N0} {tailResult.ComputationTime.TotalMilliseconds,10:F2} │");
            }

            Console.WriteLine("└─────────────┴─────────────────────┴─────────────────────┴─────────────────────┘");
        }

        /// <summary>
        /// Provides detailed optimization recommendations
        /// </summary>
        private void ProvideOptimizationRecommendations()
        {
            Console.WriteLine("\n🚀 OPTIMIZATION RECOMMENDATIONS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            Console.WriteLine("📋 TIME COMPLEXITY ANALYSIS:");
            Console.WriteLine("   • Basic Recursive: O(n) - Linear time, but with function call overhead");
            Console.WriteLine("   • Memoized Recursive: O(n) - Linear time with caching benefits");
            Console.WriteLine("   • Tail Recursive: O(n) - Linear time, optimizable in some languages");
            Console.WriteLine("   • Advanced Recursive: O(n) - Linear time with additional calculations");

            Console.WriteLine("\n📋 SPACE COMPLEXITY ANALYSIS:");
            Console.WriteLine("   • Basic Recursive: O(n) - Call stack grows with recursion depth");
            Console.WriteLine("   • Memoized Recursive: O(n) - Additional space for cache storage");
            Console.WriteLine("   • Tail Recursive: O(n) - Call stack (O(1) with tail call optimization)");
            Console.WriteLine("   • Advanced Recursive: O(n) - Call stack plus additional variables");

            Console.WriteLine("\n🔧 OPTIMIZATION TECHNIQUES:");
            Console.WriteLine("   1. Memoization: Cache results to avoid redundant calculations[9][10]");
            Console.WriteLine("   2. Tail Recursion: Structure recursion for potential compiler optimization[13]");
            Console.WriteLine("   3. Iterative Conversion: Replace recursion with loops for better performance");
            Console.WriteLine("   4. Batch Processing: Calculate multiple periods in single recursive call");
            Console.WriteLine("   5. Lazy Evaluation: Compute values only when needed[9]");

            Console.WriteLine("\n💡 PRACTICAL RECOMMENDATIONS:");
            Console.WriteLine("   ✅ Use memoization for overlapping subproblems");
            Console.WriteLine("   ✅ Consider iterative solutions for simple linear growth");
            Console.WriteLine("   ✅ Implement depth limits to prevent stack overflow");
            Console.WriteLine("   ✅ Cache frequently accessed calculations");
            Console.WriteLine("   ✅ Use tail recursion where language supports optimization");
            Console.WriteLine("   ⚠️  Monitor stack depth for large datasets");
            Console.WriteLine("   ⚠️  Profile memory usage with caching strategies");
        }
    }
}
