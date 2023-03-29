using System;

namespace BethanysPieShopHRM
{
    public class BethanysPieShopHRM
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bethany's Pie Show Emplyee App\n");

            Utilities.CheckForExistingEmployeesFile();
            string userSelect;
            do
            {
                Console.WriteLine("Select an action:");
                Console.WriteLine("1: Register employee");
                Console.WriteLine("2: View all employee");
                Console.WriteLine("3: Save data");
                Console.WriteLine("4: Load data");
                Console.WriteLine("9: Quit application");
                Console.Write("Your Selection: ");
                
                userSelect = Console.ReadLine();
                switch (userSelect) 
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "9":
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }while (userSelect != "9") ;

            Console.WriteLine("Thanks for using the application");
            Console.ReadKey();

        }
    }
}