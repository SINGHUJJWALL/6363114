using System;

namespace ECommerceSearchPlatform
{
    public class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public DateTime DateAdded { get; set; }
        public double Rating { get; set; }

        public Product(int productId, string productName, string category,
                      decimal price, string brand, int stockQuantity, double rating = 0.0)
        {
            ProductId = productId;
            ProductName = productName ?? string.Empty;
            Category = category ?? string.Empty;
            Price = price;
            Brand = brand ?? string.Empty;
            StockQuantity = stockQuantity;
            DateAdded = DateTime.Now;
            Rating = rating;
        }

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return ProductId.CompareTo(other.ProductId);
        }

        public bool MatchesSearchCriteria(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return false;

            string lowerSearchTerm = searchTerm.ToLower();

            return ProductName.ToLower().Contains(lowerSearchTerm) ||
                   Category.ToLower().Contains(lowerSearchTerm) ||
                   Brand.ToLower().Contains(lowerSearchTerm) ||
                   ProductId.ToString().Contains(searchTerm);
        }

        public override string ToString()
        {
            return $"[{ProductId}] {ProductName} | {Category} | {Brand} | ${Price:F2} | Stock: {StockQuantity} | Rating: {Rating:F1}★";
        }

        public override bool Equals(object? obj)
        {
            return obj is Product product && ProductId == product.ProductId;
        }

        public override int GetHashCode()
        {
            return ProductId.GetHashCode();
        }
    }
}
