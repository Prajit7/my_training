using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApp.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; } = 1;
    }
    public static class ProductRepo
    {
        private static List<Products> _repo = new List<Products>();

        static ProductRepo()
        {
           getAll();
        }
        public static List<Products> AllProduct => _repo;

        private static void getAll()
        {
            
            _repo.Add(new Products
            {
                ProductId = 1,
                Image = @".\Images\benz.jfif",
                Price = 2500000,
                ProductName = "Mercendes Benz"
            });
            _repo.Add(new Products
            {
                ProductId = 2,
                Image = @".\Images\desktop.jfif",
                Price = 89000,
                ProductName = "HP Desktop i7"
            });
            _repo.Add(new Products
            {
                ProductId = 3,
                Image = @".\Images\iphone.jfif",
                Price = 115000,
                ProductName = "IPhone 14 Pro"
            });
            _repo.Add(new Products
            {
                ProductId = 4,
                Image = @".\Images\laptop.jfif",
                Price = 69000,
                ProductName = "Dell Insprion 5000"
            });
            _repo.Add(new Products
            {
                ProductId = 5,
                Image = @".\Images\powerbank.jfif",
                Price = 1000,
                ProductName = "Samsung Power Bank 10000mah"
            });

        }
        public static void UpdateProduct(Products product)
        {
            var found = _repo.Find((p) => p.ProductId == product.ProductId);
            found.ProductName = product.ProductName;
            found.Price = product.Price;
        }

        public static void DeleteProduct(int id)
        {
            var found = _repo.Find((p) => p.ProductId == id);
            _repo.Remove(found);
        }
        public static void AddNewProduct(Products product) => _repo.Add(product);
    }
}