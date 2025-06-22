using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ECommerceSearchPlatform
{
    public static class SearchAlgorithms
    {
        public static SearchResult LinearSearch(Product[] products, int targetProductId)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int comparisons = 0;

            Console.WriteLine($"🔍 Starting Linear Search for Product ID: {targetProductId}");
            Console.WriteLine($"   Array Size: {products.Length} products");

            for (int i = 0; i < products.Length; i++)
            {
                comparisons++;
                Console.WriteLine($"   Comparison #{comparisons}: Checking position {i} (ID: {products[i].ProductId})");

                if (products[i].ProductId == targetProductId)
                {
                    stopwatch.Stop();
                    Console.WriteLine($"   ✅ FOUND at index {i}!");

                    return new SearchResult
                    {
                        Found = true,
                        Product = products[i],
                        Index = i,
                        Comparisons = comparisons,
                        ElapsedTime = stopwatch.Elapsed,
                        Algorithm = "Linear Search"
                    };
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"   ❌ NOT FOUND after {comparisons} comparisons");

            return new SearchResult
            {
                Found = false,
                Product = null,
                Index = -1,
                Comparisons = comparisons,
                ElapsedTime = stopwatch.Elapsed,
                Algorithm = "Linear Search"
            };
        }

        public static List<SearchResult> LinearSearchByName(Product[] products, string searchTerm)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<SearchResult> results = new List<SearchResult>();
            int comparisons = 0;

            Console.WriteLine($"🔍 Starting Linear Search by Name: '{searchTerm}'");

            for (int i = 0; i < products.Length; i++)
            {
                comparisons++;
                if (products[i].MatchesSearchCriteria(searchTerm))
                {
                    results.Add(new SearchResult
                    {
                        Found = true,
                        Product = products[i],
                        Index = i,
                        Comparisons = comparisons,
                        ElapsedTime = stopwatch.Elapsed,
                        Algorithm = "Linear Search (Name)"
                    });
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"   Found {results.Count} matches in {comparisons} comparisons");

            return results;
        }

        public static SearchResult BinarySearch(Product[] sortedProducts, int targetProductId)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int comparisons = 0;
            int left = 0;
            int right = sortedProducts.Length - 1;

            Console.WriteLine($"🎯 Starting Binary Search for Product ID: {targetProductId}");
            Console.WriteLine($"   Sorted Array Size: {sortedProducts.Length} products");
            Console.WriteLine($"   Search Range: [{left}, {right}]");

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                comparisons++;

                Console.WriteLine($"   Comparison #{comparisons}: Checking middle position {mid} (ID: {sortedProducts[mid].ProductId})");
                Console.WriteLine($"   Current range: [{left}, {right}]");

                if (sortedProducts[mid].ProductId == targetProductId)
                {
                    stopwatch.Stop();
                    Console.WriteLine($"   ✅ FOUND at index {mid}!");

                    return new SearchResult
                    {
                        Found = true,
                        Product = sortedProducts[mid],
                        Index = mid,
                        Comparisons = comparisons,
                        ElapsedTime = stopwatch.Elapsed,
                        Algorithm = "Binary Search"
                    };
                }
                else if (sortedProducts[mid].ProductId < targetProductId)
                {
                    left = mid + 1;
                    Console.WriteLine($"   Target is greater, searching right half: [{left}, {right}]");
                }
                else
                {
                    right = mid - 1;
                    Console.WriteLine($"   Target is smaller, searching left half: [{left}, {right}]");
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"   ❌ NOT FOUND after {comparisons} comparisons");

            return new SearchResult
            {
                Found = false,
                Product = null,
                Index = -1,
                Comparisons = comparisons,
                ElapsedTime = stopwatch.Elapsed,
                Algorithm = "Binary Search"
            };
        }

        public static SearchResult BinarySearchRecursive(Product[] sortedProducts, int targetProductId)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int comparisons = 0;

            Console.WriteLine($"🔄 Starting Recursive Binary Search for Product ID: {targetProductId}");

            int index = BinarySearchRecursiveHelper(sortedProducts, targetProductId, 0,
                                                  sortedProducts.Length - 1, ref comparisons);

            stopwatch.Stop();

            if (index != -1)
            {
                Console.WriteLine($"   ✅ FOUND at index {index}!");
                return new SearchResult
                {
                    Found = true,
                    Product = sortedProducts[index],
                    Index = index,
                    Comparisons = comparisons,
                    ElapsedTime = stopwatch.Elapsed,
                    Algorithm = "Binary Search (Recursive)"
                };
            }
            else
            {
                Console.WriteLine($"   ❌ NOT FOUND after {comparisons} comparisons");
                return new SearchResult
                {
                    Found = false,
                    Product = null,
                    Index = -1,
                    Comparisons = comparisons,
                    ElapsedTime = stopwatch.Elapsed,
                    Algorithm = "Binary Search (Recursive)"
                };
            }
        }

        private static int BinarySearchRecursiveHelper(Product[] array, int target, int left, int right, ref int comparisons)
        {
            if (left > right)
                return -1;

            int mid = left + (right - left) / 2;
            comparisons++;

            Console.WriteLine($"   Recursive call: range [{left}, {right}], mid={mid} (ID: {array[mid].ProductId})");

            if (array[mid].ProductId == target)
                return mid;
            else if (array[mid].ProductId < target)
                return BinarySearchRecursiveHelper(array, target, mid + 1, right, ref comparisons);
            else
                return BinarySearchRecursiveHelper(array, target, left, mid - 1, ref comparisons);
        }
    }

    public class SearchResult
    {
        public bool Found { get; set; }
        public Product? Product { get; set; }
        public int Index { get; set; }
        public int Comparisons { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public string Algorithm { get; set; } = string.Empty;

        public void DisplayResult()
        {
            Console.WriteLine($"\n📊 SEARCH RESULT - {Algorithm}");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine($"   Result: {(Found ? "FOUND ✅" : "NOT FOUND ❌")}");
            if (Found && Product != null)
            {
                Console.WriteLine($"   Product: {Product}");
                Console.WriteLine($"   Index: {Index}");
            }
            Console.WriteLine($"   Comparisons: {Comparisons}");
            Console.WriteLine($"   Time Elapsed: {ElapsedTime.TotalMicroseconds:F2} microseconds");
            Console.WriteLine($"   Time Elapsed: {ElapsedTime.TotalMilliseconds:F4} milliseconds");
        }
    }
}
