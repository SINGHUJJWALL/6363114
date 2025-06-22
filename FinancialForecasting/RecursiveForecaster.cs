using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FinancialForecastingTool
{
    /// <summary>
    /// Implements various recursive algorithms for financial forecasting
    /// Demonstrates different approaches and their complexity characteristics
    /// </summary>
    public class RecursiveForecaster
    {
        private int _recursiveCallCount;
        private Random _random;
        private Dictionary<string, decimal> _memoCache;

        public RecursiveForecaster()
        {
            _random = new Random();
            _memoCache = new Dictionary<string, decimal>();
        }

        /// <summary>
        /// Basic recursive compound growth calculation
        /// Time Complexity: O(n) where n is the number of periods
        /// Space Complexity: O(n) due to call stack
        /// </summary>
        public ForecastResult BasicRecursiveForecast(ForecastingParameters parameters)
        {
            Console.WriteLine("🔄 Starting Basic Recursive Forecast...");
            Console.WriteLine($"   Initial Value: ${parameters.InitialValue:N2}");
            Console.WriteLine($"   Growth Rate: {parameters.BaseGrowthRate:P2}");
            Console.WriteLine($"   Periods: {parameters.ForecastPeriods}");

            Stopwatch stopwatch = Stopwatch.StartNew();
            _recursiveCallCount = 0;

            var result = new ForecastResult { Algorithm = "Basic Recursive Forecast" };

            // Generate forecasted values recursively
            for (int period = 0; period < parameters.ForecastPeriods; period++)
            {
                decimal forecastedValue = CalculateRecursiveValue(
                    parameters.InitialValue,
                    parameters.BaseGrowthRate,
                    period
                );

                var dataPoint = new FinancialDataPoint(
                    DateTime.Now.AddMonths(period),
                    forecastedValue,
                    parameters.BaseGrowthRate,
                    $"Period {period + 1} forecast"
                );

                result.ForecastedValues.Add(dataPoint);

                Console.WriteLine($"   Period {period + 1}: ${forecastedValue:N2} (Calls: {_recursiveCallCount})");
            }

            stopwatch.Stop();
            result.RecursiveCalls = _recursiveCallCount;
            result.ComputationTime = stopwatch.Elapsed;

            return result;
        }

        /// <summary>
        /// Recursive calculation of compound growth
        /// Base case: period 0 returns initial value
        /// Recursive case: previous value * (1 + growth rate)
        /// </summary>
        private decimal CalculateRecursiveValue(decimal initialValue, double growthRate, int period)
        {
            _recursiveCallCount++;

            Console.WriteLine($"     Recursive call: period={period}, calls={_recursiveCallCount}");

            // Base case: period 0
            if (period == 0)
            {
                return initialValue;
            }

            // Recursive case: calculate previous period and apply growth
            decimal previousValue = CalculateRecursiveValue(initialValue, growthRate, period - 1);
            return previousValue * (decimal)(1 + growthRate);
        }

        /// <summary>
        /// Optimized recursive forecast using memoization
        /// Time Complexity: O(n) with memoization
        /// Space Complexity: O(n) for both cache and call stack
        /// </summary>
        public ForecastResult MemoizedRecursiveForecast(ForecastingParameters parameters)
        {
            Console.WriteLine("🧠 Starting Memoized Recursive Forecast...");

            Stopwatch stopwatch = Stopwatch.StartNew();
            _recursiveCallCount = 0;
            _memoCache.Clear();

            var result = new ForecastResult { Algorithm = "Memoized Recursive Forecast" };

            for (int period = 0; period < parameters.ForecastPeriods; period++)
            {
                decimal forecastedValue = CalculateMemoizedValue(
                    parameters.InitialValue,
                    parameters.BaseGrowthRate,
                    period
                );

                var dataPoint = new FinancialDataPoint(
                    DateTime.Now.AddMonths(period),
                    forecastedValue,
                    parameters.BaseGrowthRate,
                    $"Memoized Period {period + 1}"
                );

                result.ForecastedValues.Add(dataPoint);

                Console.WriteLine($"   Period {period + 1}: ${forecastedValue:N2} (Calls: {_recursiveCallCount}, Cache size: {_memoCache.Count})");
            }

            stopwatch.Stop();
            result.RecursiveCalls = _recursiveCallCount;
            result.ComputationTime = stopwatch.Elapsed;
            result.Metadata["CacheHits"] = _memoCache.Count;

            return result;
        }

        /// <summary>
        /// Memoized recursive calculation with caching
        /// Stores previously calculated values to avoid redundant computation
        /// </summary>
        private decimal CalculateMemoizedValue(decimal initialValue, double growthRate, int period)
        {
            string cacheKey = $"{initialValue}_{growthRate}_{period}";

            // Check cache first
            if (_memoCache.ContainsKey(cacheKey))
            {
                Console.WriteLine($"     Cache hit for period {period}");
                return _memoCache[cacheKey];
            }

            _recursiveCallCount++;
            Console.WriteLine($"     Computing period {period}, calls={_recursiveCallCount}");

            decimal result;

            if (period == 0)
            {
                result = initialValue;
            }
            else
            {
                decimal previousValue = CalculateMemoizedValue(initialValue, growthRate, period - 1);
                result = previousValue * (decimal)(1 + growthRate);
            }

            // Store in cache
            _memoCache[cacheKey] = result;
            return result;
        }

        /// <summary>
        /// Advanced recursive forecast with variable growth rates and volatility
        /// Simulates more realistic financial scenarios
        /// </summary>
        public ForecastResult AdvancedRecursiveForecast(ForecastingParameters parameters)
        {
            Console.WriteLine("🚀 Starting Advanced Recursive Forecast...");
            Console.WriteLine($"   Base Growth Rate: {parameters.BaseGrowthRate:P2}");
            Console.WriteLine($"   Volatility: {parameters.Volatility:P2}");
            Console.WriteLine($"   Inflation Rate: {parameters.InflationRate:P2}");

            Stopwatch stopwatch = Stopwatch.StartNew();
            _recursiveCallCount = 0;

            var result = new ForecastResult { Algorithm = "Advanced Recursive Forecast" };

            for (int period = 0; period < parameters.ForecastPeriods; period++)
            {
                // Calculate variable growth rate with volatility
                double adjustedGrowthRate = CalculateAdjustedGrowthRate(
                    parameters.BaseGrowthRate,
                    parameters.Volatility,
                    parameters.InflationRate,
                    period
                );

                decimal forecastedValue = CalculateAdvancedRecursiveValue(
                    parameters.InitialValue,
                    adjustedGrowthRate,
                    period
                );

                var dataPoint = new FinancialDataPoint(
                    DateTime.Now.AddMonths(period),
                    forecastedValue,
                    adjustedGrowthRate,
                    $"Advanced Period {period + 1}"
                );

                result.ForecastedValues.Add(dataPoint);

                Console.WriteLine($"   Period {period + 1}: ${forecastedValue:N2} (Rate: {adjustedGrowthRate:P2})");
            }

            stopwatch.Stop();
            result.RecursiveCalls = _recursiveCallCount;
            result.ComputationTime = stopwatch.Elapsed;

            return result;
        }

        /// <summary>
        /// Calculates adjusted growth rate with volatility and market factors
        /// </summary>
        private double CalculateAdjustedGrowthRate(double baseRate, double volatility, double inflation, int period)
        {
            // Add random volatility
            double volatilityFactor = (_random.NextDouble() - 0.5) * 2 * volatility;

            // Add cyclical component (simulates market cycles)
            double cyclicalFactor = Math.Sin(period * Math.PI / 12) * 0.01;

            // Adjust for inflation
            double inflationAdjustment = inflation / 12; // Monthly inflation

            return baseRate + volatilityFactor + cyclicalFactor - inflationAdjustment;
        }

        /// <summary>
        /// Advanced recursive calculation with dynamic growth rates
        /// </summary>
        private decimal CalculateAdvancedRecursiveValue(decimal initialValue, double growthRate, int period)
        {
            _recursiveCallCount++;

            if (period == 0)
            {
                return initialValue;
            }

            // For advanced calculation, we need to recalculate each period with its specific growth rate
            // This is more realistic but computationally intensive
            decimal previousValue = CalculateAdvancedRecursiveValue(initialValue, growthRate, period - 1);

            // Apply current period's growth rate
            return previousValue * (decimal)(1 + growthRate);
        }

        /// <summary>
        /// Tail-recursive optimization attempt (limited in C# due to lack of TCO)
        /// Demonstrates the concept even though C# doesn't optimize tail calls
        /// </summary>
        public ForecastResult TailRecursiveForecast(ForecastingParameters parameters)
        {
            Console.WriteLine("🔄 Starting Tail-Recursive Forecast...");

            Stopwatch stopwatch = Stopwatch.StartNew();
            _recursiveCallCount = 0;

            var result = new ForecastResult { Algorithm = "Tail-Recursive Forecast" };

            // Calculate all values using tail recursion
            var values = new List<decimal>();
            CalculateTailRecursive(
                parameters.InitialValue,
                parameters.BaseGrowthRate,
                parameters.ForecastPeriods,
                0,
                values
            );

            // Convert to data points
            for (int i = 0; i < values.Count; i++)
            {
                var dataPoint = new FinancialDataPoint(
                    DateTime.Now.AddMonths(i),
                    values[i],
                    parameters.BaseGrowthRate,
                    $"Tail-recursive Period {i + 1}"
                );
                result.ForecastedValues.Add(dataPoint);
            }

            stopwatch.Stop();
            result.RecursiveCalls = _recursiveCallCount;
            result.ComputationTime = stopwatch.Elapsed;

            return result;
        }

        /// <summary>
        /// Tail-recursive helper function
        /// The recursive call is the last operation (tail position)
        /// </summary>
        private void CalculateTailRecursive(decimal currentValue, double growthRate, int remainingPeriods, int currentPeriod, List<decimal> accumulator)
        {
            _recursiveCallCount++;

            // Add current value to results
            accumulator.Add(currentValue);

            Console.WriteLine($"   Tail-recursive: Period {currentPeriod + 1}, Value: ${currentValue:N2}, Remaining: {remainingPeriods}");

            // Base case: no more periods to calculate
            if (remainingPeriods <= 1)
            {
                return;
            }

            // Tail-recursive call: calculate next period
            decimal nextValue = currentValue * (decimal)(1 + growthRate);
            CalculateTailRecursive(nextValue, growthRate, remainingPeriods - 1, currentPeriod + 1, accumulator);
        }
    }
}
