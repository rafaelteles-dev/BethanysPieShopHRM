using BethanysPieShopHRM.HR;
using System;

namespace BethanysPieShopHRM
{
    public class BethanysPieShopHRM
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

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
                        Utilities.RegisterEmployee(employees);
                        break;
                    case "2":
                        Console.WriteLine("View all employee still codding...");
                        break;
                    case "3":
                        Utilities.SaveEmployees(employees);
                        break;
                    case "4":
                        Utilities.LoadEmployees(employees);
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