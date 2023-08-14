using Week_2_Day_1.Models;

namespace Week_2_Day_1.Data
{
    public static class SampleData
    {
        public static List<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Shirt", Price = 19.99M },
                new Product { Id = 2, Name = "Jeans", Price = 29.99M },
                new Product { Id = 3, Name = "Shoes", Price = 9.99M }
            };
            return products;
        }
    }
}
