using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceSearchPlatform
{
    public class ECommercePlatform
    {
        private Product[] _products = Array.Empty<Product>();
        private Product[] _sortedProducts = Array.Empty<Product>();
        private Random _random;

        public ECommercePlatform()
        {
            _random = new Random();
            InitializeProducts();
            PrepareSortedArray();
        }

        private void InitializeProducts()
        {
            _products = new Product[]
            {
                new Product(1001, "iPhone 15 Pro", "Electronics", 999.99m, "Apple", 50, 4.8),
                new Product(2003, "Samsung Galaxy S24", "Electronics", 899.99m, "Samsung", 75, 4.7),
                new Product(1505, "MacBook Air M3", "Computers", 1299.99m, "Apple", 30, 4.9),
                new Product(3007, "Nike Air Max 270", "Footwear", 149.99m, "Nike", 120, 4.5),
                new Product(4002, "Adidas Ultraboost 22", "Footwear", 179.99m, "Adidas", 95, 4.6),
                new Product(5001, "Sony WH-1000XM5", "Audio", 399.99m, "Sony", 60, 4.8),
                new Product(6008, "Dell XPS 13", "Computers", 1099.99m, "Dell", 40, 4.4),
                new Product(7004, "Canon EOS R6", "Photography", 2499.99m, "Canon", 15, 4.7),
                new Product(8009, "Levi's 501 Jeans", "Clothing", 79.99m, "Levi's", 200, 4.3),
                new Product(9006, "Nintendo Switch OLED", "Gaming", 349.99m, "Nintendo", 85, 4.6),
                new Product(1010, "AirPods Pro 2", "Audio", 249.99m, "Apple", 100, 4.7),
                new Product(1112, "Google Pixel 8", "Electronics", 699.99m, "Google", 65, 4.5),
                new Product(1213, "Microsoft Surface Pro 9", "Computers", 1299.99m, "Microsoft", 25, 4.4),
                new Product(1314, "Bose QuietComfort 45", "Audio", 329.99m, "Bose", 45, 4.6),
                new Product(1415, "HP Pavilion 15", "Computers", 799.99m, "HP", 55, 4.2)
            };

            Console.WriteLine($"📦 Initialized product catalog with {_products.Length} products");
        }

        private void PrepareSortedArray()
        {
            _sortedProducts = new Product[_products.Length];
            Array.Copy(_products, _sortedProducts, _products.Length);
            Array.Sort(_sortedProducts);

            Console.WriteLine("🔄 Created sorted array for binary search optimization");
        }

        public void DisplayAllProducts()
        {
            Console.WriteLine("\n📋 PRODUCT CATALOG");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Original Order:");
            for (int i = 0; i < _products.Length; i++)
            {
                Console.WriteLine($"  {i:D2}: {_products[i]}");
            }

            Console.WriteLine("\nSorted Order (by Product ID):");
            for (int i = 0; i < _sortedProducts.Length; i++)
            {
                Console.WriteLine($"  {i:D2}: {_sortedProducts[i]}");
            }
        }

        public void PerformSearchComparison(int targetProductId)
        {
            Console.WriteLine($"\n🔍 SEARCH ALGORITHM COMPARISON");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine($"Target Product ID: {targetProductId}");
            Console.WriteLine($"Dataset Size: {_products.Length} products\n");

            var linearResult = SearchAlgorithms.LinearSearch(_products, targetProductId);
            linearResult.DisplayResult();

            Console.WriteLine("\n2️⃣ BINARY SEARCH ANALYSIS");
            Console.WriteLine("──────────────────────────");
            var binaryResult = SearchAlgorithms.BinarySearch(_sortedProducts, targetProductId);
            binaryResult.DisplayResult();

            Console.WriteLine("\n3️⃣ RECURSIVE BINARY SEARCH ANALYSIS");
            Console.WriteLine("────────────────────────────────────");
            var recursiveResult = SearchAlgorithms.BinarySearchRecursive(_sortedProducts, targetProductId);
            recursiveResult.DisplayResult();

            DisplayPerformanceComparison(linearResult, binaryResult, recursiveResult);
        }

        private void DisplayPerformanceComparison(SearchResult linear, SearchResult binary, SearchResult recursive)
        {
            Console.WriteLine("\n📊 PERFORMANCE COMPARISON & BIG O ANALYSIS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            Console.WriteLine("┌─────────────────────┬─────────────┬─────────────┬──────────────────┐");
            Console.WriteLine("│ Algorithm           │ Comparisons │ Time (μs)   │ Big O Complexity │");
            Console.WriteLine("├─────────────────────┼─────────────┼─────────────┼──────────────────┤");
            Console.WriteLine($"│ Linear Search       │ {linear.Comparisons,11} │ {linear.ElapsedTime.TotalMicroseconds,11:F2} │ O(n)             │");
            Console.WriteLine($"│ Binary Search       │ {binary.Comparisons,11} │ {binary.ElapsedTime.TotalMicroseconds,11:F2} │ O(log n)         │");
            Console.WriteLine($"│ Binary (Recursive)  │ {recursive.Comparisons,11} │ {recursive.ElapsedTime.TotalMicroseconds,11:F2} │ O(log n)         │");
            Console.WriteLine("└─────────────────────┴─────────────┴─────────────┴──────────────────┘");

            if (linear.Comparisons > 0 && binary.Comparisons > 0)
            {
                double comparisonImprovement = (double)linear.Comparisons / binary.Comparisons;
                double timeImprovement = linear.ElapsedTime.TotalMicroseconds / binary.ElapsedTime.TotalMicroseconds;

                Console.WriteLine($"\n🚀 EFFICIENCY IMPROVEMENTS:");
                Console.WriteLine($"   Binary search used {comparisonImprovement:F1}x fewer comparisons");
                Console.WriteLine($"   Binary search was {timeImprovement:F1}x faster in execution time");
            }
        }

        public void PerformScalabilityAnalysis()
        {
            Console.WriteLine("\n📈 SCALABILITY ANALYSIS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            int[] datasetSizes = { 100, 1000, 10000, 100000 };

            Console.WriteLine("Theoretical Comparisons for Different Dataset Sizes:");
            Console.WriteLine("┌─────────────┬─────────────────┬─────────────────┬─────────────────┐");
            Console.WriteLine("│ Dataset     │ Linear Search   │ Binary Search   │ Improvement     │");
            Console.WriteLine("│ Size (n)    │ O(n) - Worst    │ O(log n) - Worst│ Factor          │");
            Console.WriteLine("├─────────────┼─────────────────┼─────────────────┼─────────────────┤");

            foreach (int n in datasetSizes)
            {
                int linearWorst = n;
                int binaryWorst = (int)Math.Ceiling(Math.Log2(n));
                double improvement = (double)linearWorst / binaryWorst;

                Console.WriteLine($"│ {n,11:N0} │ {linearWorst,15:N0} │ {binaryWorst,15} │ {improvement,15:F1}x │");
            }
            Console.WriteLine("└─────────────┴─────────────────┴─────────────────┴─────────────────┘");
        }

        public void SearchByName(string searchTerm)
        {
            Console.WriteLine($"\n🔍 SEARCHING BY NAME: '{searchTerm}'");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            var results = SearchAlgorithms.LinearSearchByName(_products, searchTerm);

            if (results.Count > 0)
            {
                Console.WriteLine($"\n✅ Found {results.Count} matching products:");
                foreach (var result in results)
                {
                    if (result.Product != null)
                    {
                        Console.WriteLine($"   • {result.Product}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"\n❌ No products found matching '{searchTerm}'");
            }
        }

        public void DemonstrateCaseAnalysis()
        {
            Console.WriteLine("\n🎯 CASE ANALYSIS DEMONSTRATION");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");

            Console.WriteLine("🟢 BEST CASE SCENARIO (Element at first position):");
            PerformSearchComparison(_products[0].ProductId);

            Console.WriteLine("\n" + new string('═', 79));

            Console.WriteLine("🔴 WORST CASE SCENARIO (Element at last position):");
            PerformSearchComparison(_products[_products.Length - 1].ProductId);

            Console.WriteLine("\n" + new string('═', 79));

            Console.WriteLine("🟡 AVERAGE CASE SCENARIO (Element in middle):");
            PerformSearchComparison(_products[_products.Length / 2].ProductId);
        }
    }
}
