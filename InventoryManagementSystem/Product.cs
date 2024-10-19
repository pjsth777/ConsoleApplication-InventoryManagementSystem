using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    public class Product
    {
        // ------------------------------------------------------------------------------
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // ------------------------------------------------------------------------------

        public Product(int id, string name, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        // ------------------------------------------------------------------------------

        public override string ToString()
        {
            return $"{Id}, {Name}, {Price:C}, {Quantity}";
        }

        // ------------------------------------------------------------------------------

        public decimal TotalValue()
        {
            return Price * Quantity;
        }

        // ------------------------------------------------------------------------------
    }
}
