
using InventoryManagementSystem;

class Program
{
    // ------------------------------------------------------------------------------
    static void Main(string[] args)
    {

        // ------------------------------------------------------------------------------
        InventoryManager manager = new InventoryManager();
        bool running = true;

        // ------------------------------------------------------------------------------

        while (running)
        {
            Console.WriteLine("\nInventory Management System");
            Console.WriteLine("1. List Products");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Search Product By Name");
            Console.WriteLine("6. Show Total Inventory Value");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    manager.ListProducts();
                    break;
                case "2":
                    AddNewProduct(manager);
                    break;
                case "3":
                    UpdateExistingProduct(manager);
                    break;
                case "4":
                    RemoveProduct(manager);
                    break;
                case "5":
                    SearchProduct(manager);
                    break;
                case "6":
                    manager.ShowTotalInventoryValue();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        // ------------------------------------------------------------------------------

    }

    // ------------------------------------------------------------------------------

    private static void AddNewProduct(InventoryManager manager)
    {
        int id = Utils.GetValidInt("Enter product ID: ");
        Console.Write("Enter product name");
        string name = Console.ReadLine();
        decimal price = Utils.GetValidDecimal("Enter product price: ");
        int quantity = Utils.GetValidInt("Enter product quantity: ");

        Product product = new Product(id, name, price, quantity);
        manager.AddProduct(product);
    }

    // ------------------------------------------------------------------------------

    private static void UpdateExistingProduct(InventoryManager manager)
    {
        int id = Utils.GetValidInt("Enter product ID: ");
        Console.Write("Enter new product name: ");
        string name = Console.ReadLine();
        decimal price = Utils.GetValidDecimal("Enter new product price: ");
        int quantity = Utils.GetValidInt("Enter new product quantity: ");

        manager.UpdateProduct(id, name, price, quantity);
    }

    // ------------------------------------------------------------------------------

    private static void RemoveProduct(InventoryManager manager)
    {
        int id = Utils.GetValidInt("Enter product ID to remove: ");
        manager.RemoveProduct(id);
    }

    // ------------------------------------------------------------------------------
    
    private static void SearchProduct(InventoryManager manager)
    {
        Console.Write("Enter product name to search: ");
        string name = Console.ReadLine();
        manager.SearchProductByName(name);
    }

    // ------------------------------------------------------------------------------

}

