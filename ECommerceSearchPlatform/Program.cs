using System;

namespace ECommerceSearchPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    E-COMMERCE SEARCH OPTIMIZATION                            ║");
            Console.WriteLine("║                     Big O Notation Analysis                                  ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════╝\n");

            try
            {
                // Initialize the e-commerce platform
                ECommercePlatform platform = new ECommercePlatform();

                // Display product catalog
                platform.DisplayAllProducts();

                // Demonstrate different case scenarios
                platform.DemonstrateCaseAnalysis();

                // Perform scalability analysis
                platform.PerformScalabilityAnalysis();

                // Search by name demonstration
                platform.SearchByName("Apple");
                platform.SearchByName("Nike");

                // Interactive search
                PerformInteractiveSearch(platform);

                // Final analysis and recommendations
                DisplayFinalAnalysis();
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

        static void PerformInteractiveSearch(ECommercePlatform platform)
        {
            Console.WriteLine("\n🎮 INTERACTIVE SEARCH DEMONSTRATION");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            int[] testProductIds = { 1001, 5001, 9999, 1415 }; // Mix of existing and non-existing

            foreach (int productId in testProductIds)
            {
                Console.WriteLine($"\n🔍 Testing with Product ID: {productId}");
                Console.WriteLine(new string('─', 50));
                platform.PerformSearchComparison(productId);
            }
        }

        static void DisplayFinalAnalysis()
        {
            Console.WriteLine("\n🎯 FINAL ANALYSIS & RECOMMENDATIONS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            Console.WriteLine("📊 ALGORITHM COMPARISON SUMMARY:");
            Console.WriteLine("┌─────────────────────┬─────────────────┬─────────────────┬─────────────────┐");
            Console.WriteLine("│ Aspect              │ Linear Search   │ Binary Search   │ Winner          │");
            Console.WriteLine("├─────────────────────┼─────────────────┼─────────────────┼─────────────────┤");
            Console.WriteLine("│ Time Complexity     │ O(n)           │ O(log n)        │ Binary Search   │");
            Console.WriteLine("│ Space Complexity    │ O(1)           │ O(1)            │ Tie             │");
            Console.WriteLine("│ Preprocessing       │ None           │ Sorting O(n log n) │ Linear Search   │");
            Console.WriteLine("│ Data Structure      │ Any array      │ Sorted array    │ Linear Search   │");
            Console.WriteLine("│ Best for Small Data │ Good           │ Overkill        │ Linear Search   │");
            Console.WriteLine("│ Best for Large Data │ Poor           │ Excellent       │ Binary Search   │");
            Console.WriteLine("│ Implementation      │ Simple         │ Moderate        │ Linear Search   │");
            Console.WriteLine("└─────────────────────┴─────────────────┴─────────────────┴─────────────────┘");

            Console.WriteLine("\n🏆 RECOMMENDATIONS FOR E-COMMERCE PLATFORM:");
            Console.WriteLine("   ✅ Use Binary Search for:");
            Console.WriteLine("      • Product ID searches (numeric, easily sortable)");
            Console.WriteLine("      • Price range queries (when sorted by price)");
            Console.WriteLine("      • Large product catalogs (>1000 products)");
            Console.WriteLine("      • Frequently accessed data");

            Console.WriteLine("\n   ✅ Use Linear Search for:");
            Console.WriteLine("      • Text-based searches (product names, descriptions)");
            Console.WriteLine("      • Small product catalogs (<100 products)");
            Console.WriteLine("      • Unsorted or frequently changing data");
            Console.WriteLine("      • Multiple criteria searches");

            Console.WriteLine("\n   🚀 OPTIMIZATION STRATEGIES:");
            Console.WriteLine("      • Implement hybrid approach: Binary for IDs, Linear for text");
            Console.WriteLine("      • Use indexing for frequently searched attributes");
            Console.WriteLine("      • Consider hash tables for O(1) average case lookups");
            Console.WriteLine("      • Implement caching for popular search queries");
            Console.WriteLine("      • Use database indexing for production systems");
        }
    }
}
