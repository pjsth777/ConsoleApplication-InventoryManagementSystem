using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    public class InventoryManager
    {
        // ------------------------------------------------------------------------------

        private List<Product> products;

        // ------------------------------------------------------------------------------

        public InventoryManager()
        {
            products = new List<Product>();
            LoadData();
        }

        // ------------------------------------------------------------------------------

        public void AddProduct(Product product)
        {
            if (products.Any(p => p.Id == product.Id))
            {
                Console.WriteLine("A product with this ID already exists.");
            }
            else
            {
                products.Add(product);
                SaveData();
                Console.WriteLine("Product added successfully.");
            }
        }

        // ------------------------------------------------------------------------------

        public void RemoveProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
                SaveData();
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        // ------------------------------------------------------------------------------

        public void UpdateProduct(int id, string name, decimal price, int quantity)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = name;
                product.Price = price;
                product.Quantity = quantity;
                SaveData();
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        // ------------------------------------------------------------------------------

        public void ListProducts()
        {
            Console.WriteLine("ID | Name | Price | Quantity");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        // ------------------------------------------------------------------------------
        
        public void SearchProductByName(string name)
        {
            var foundProducts = products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
            if (foundProducts.Count > 0)
            {
                Console.WriteLine("Matching Products: ");
                foreach(var product in foundProducts)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("No matching products found.");
            }
        }
        
        // ------------------------------------------------------------------------------

        public void ShowTotalInventoryValue()
        {
            decimal totalValue = products.Sum(p => p.TotalValue());
            Console.WriteLine($"Total Inventory Value: {totalValue:C}");
        }

        // ------------------------------------------------------------------------------

        private void SaveData()
        {
            using (StreamWriter writer = new StreamWriter("InventoryData.txt"))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.Id},{product.Name},{product.Price},{product.Quantity}");
                }
            }
        }
        
        // ------------------------------------------------------------------------------

        private void LoadData()
        {
            if (File.Exists("InventoryData.txt"))
            {
                var lines = File.ReadAllLines("InventoryData.txt");
                foreach(var line in lines)
                {
                    var parts = line.Split(",");
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    decimal price = decimal.Parse(parts[2]);
                    int quantity = int.Parse(parts[3]);

                    products.Add(new Product(id, name, price, quantity));
                }
            }
        }

        // ------------------------------------------------------------------------------
    }
}
