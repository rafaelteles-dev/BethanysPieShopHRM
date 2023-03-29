using BethanysPieShopHRM.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM
{
    internal class Utilities
    {
		private static string directory = @"C:\Projetos\BethanysPieShopHRM\";
		private static string fileName = "employees.txt";

		internal static void CheckForExistingEmployeesFile()
		{
			string path = $"{directory}{fileName}";
			bool existingFileFound = File.Exists(path);

			if(existingFileFound)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("An existing file with employee data is found!\n");
				Console.ResetColor();
			}
            else
            {
				if (!Directory.Exists(directory))
                {
					Directory.CreateDirectory(directory);
					Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Directory ready for saving files!\n");
					Console.ResetColor();
                }
            }
		}

		internal static void RegisterEmployee(List<Employee> employees)
        {
			Console.WriteLine("Creating an employee");
			Console.WriteLine("What type of employee do you want to register?");
			Console.WriteLine("1. Employee\n2. Manager\n3. Store manager\n4. Researcher\n5. Junior researcher");
			Console.Write("Your selection: ");
			string employeeType = Console.ReadLine();
			if(employeeType != "1" && employeeType != "2" && employeeType != "3" && employeeType != "4" && employeeType != "5")
			{
                Console.WriteLine("Invalid selection");
				return;
            }
			Console.Write("Enter the first name: ");
			string firstName = Console.ReadLine();
			Console.Write("Enter the last name: ");
			string lastName = Console.ReadLine();
			Console.Write("Enter the email: ");
			string email = Console.ReadLine();
			Console.Write("Enter the birth day (dd/mm/yyyy): ");
			DateTime birthDay  = DateTime.Parse(Console.ReadLine());
			Console.Write("Enter the hourly rate: ");
			string hourlyRate = Console.ReadLine();
			double rate = double.Parse(hourlyRate);//assume the input is correct

			Employee employee = null;

			switch(employeeType)
            {
				case "1":
					employee = new Employee(firstName, lastName, email, birthDay, rate);
					break;
				case "2":
					employee = new Manager(firstName, lastName, email, birthDay, rate);
					break;
				case"3":
					employee = new StoreManager(firstName, lastName, email, birthDay, rate);
					break;
				case"4":
					employee = new Researcher(firstName, lastName, email, birthDay, rate);
					break;
				case"5":
					employee = new JuniorResearcher(firstName, lastName, email, birthDay, rate);
					break;
			}
			employees.Add(employee);

			Console.WriteLine("Employee created!\n\n");
		}



	}
}
