using System;
using System.Collections.Generic;

namespace FinancialForecastingTool
{
    /// <summary>
    /// Represents financial data point with value and growth information
    /// </summary>
    public class FinancialDataPoint
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public double GrowthRate { get; set; }
        public string Description { get; set; } = string.Empty;

        public FinancialDataPoint(DateTime date, decimal value, double growthRate, string description = "")
        {
            Date = date;
            Value = value;
            GrowthRate = growthRate;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd}: ${Value:N2} (Growth: {GrowthRate:P2}) - {Description}";
        }
    }

    /// <summary>
    /// Represents forecasting parameters and configuration
    /// </summary>
    public class ForecastingParameters
    {
        public decimal InitialValue { get; set; }
        public double BaseGrowthRate { get; set; }
        public double Volatility { get; set; }
        public int ForecastPeriods { get; set; }
        public string PeriodType { get; set; } = "Monthly";
        public bool UseCompounding { get; set; } = true;
        public double InflationRate { get; set; } = 0.0;

        public ForecastingParameters(decimal initialValue, double baseGrowthRate, int forecastPeriods)
        {
            InitialValue = initialValue;
            BaseGrowthRate = baseGrowthRate;
            ForecastPeriods = forecastPeriods;
            Volatility = 0.0;
        }
    }

    /// <summary>
    /// Contains forecasting results and performance metrics
    /// </summary>
    public class ForecastResult
    {
        public List<FinancialDataPoint> ForecastedValues { get; set; } = new List<FinancialDataPoint>();
        public int RecursiveCalls { get; set; }
        public TimeSpan ComputationTime { get; set; }
        public string Algorithm { get; set; } = string.Empty;
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();

        public void DisplayResults()
        {
            Console.WriteLine($"\n📊 FORECAST RESULTS - {Algorithm}");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine($"   Total Periods Forecasted: {ForecastedValues.Count}");
            Console.WriteLine($"   Recursive Calls Made: {RecursiveCalls:N0}");
            Console.WriteLine($"   Computation Time: {ComputationTime.TotalMilliseconds:F2} ms");

            if (ForecastedValues.Count > 0)
            {
                var initialValue = ForecastedValues[0].Value;
                var finalValue = ForecastedValues[ForecastedValues.Count - 1].Value;
                var totalGrowth = ((double)(finalValue - initialValue) / (double)initialValue) * 100;

                Console.WriteLine($"   Initial Value: ${initialValue:N2}");
                Console.WriteLine($"   Final Value: ${finalValue:N2}");
                Console.WriteLine($"   Total Growth: {totalGrowth:F2}%");
            }

            Console.WriteLine("\n   Forecasted Values:");
            for (int i = 0; i < Math.Min(ForecastedValues.Count, 10); i++)
            {
                Console.WriteLine($"     Period {i + 1}: {ForecastedValues[i]}");
            }

            if (ForecastedValues.Count > 10)
            {
                Console.WriteLine($"     ... and {ForecastedValues.Count - 10} more periods");
            }
        }
    }
}
