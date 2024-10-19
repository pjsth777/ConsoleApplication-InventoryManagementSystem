using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{

    // ------------------------------------------------------------------------------
    // Utils class can be used for validation, such as validating numeric inputs
    // ------------------------------------------------------------------------------
    public class Utils
    {
        public static int GetValidInt(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            return value;
        }

        // ------------------------------------------------------------------------------

        public static decimal GetValidDecimal(string message)
        {
            decimal value;
            while(true)
            {
                Console.WriteLine(message);
                if (decimal.TryParse(Console.ReadLine(), out value))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
            }
            return value;
        }
    }

    // ------------------------------------------------------------------------------

}
