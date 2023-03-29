﻿using BethanysPieShopHRM.HR;
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

		internal static void SaveEmployees(List<Employee> employees)
        {
			string path = $"{directory}{fileName}";
			StringBuilder sb = new StringBuilder();

			foreach (Employee employee in employees)
            {
				string type = GetEmployeeType(employee);
				sb.Append($"firstName:{employee.FirstName};");
				sb.Append($"lastName:{employee.LastName};");
				sb.Append($"email:{employee.Email};");
				sb.Append($"birthDay:{employee.BirthDay.ToShortDateString()};");
				sb.Append($"hourlyRate:{employee.HourlyRate};");
				sb.Append($"type:{type};");

				sb.Append(Environment.NewLine);
            }
			File.WriteAllText(path, sb.ToString());

			Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employees saved successfuly");
			Console.ResetColor();

		}

		private static string GetEmployeeType(Employee employee)
        {
			if (employee is Manager)
				return "2";
			else if (employee is StoreManager)
				return "3";
			else if (employee is JuniorResearcher)
				return "5";
			else if (employee is Researcher)
				return "4";
			else if (employee is Employee)
				return "1";
			return "0";
        }

		internal static void LoadEmployees(List<Employee> employees)
        {
			string path = $"{directory}{fileName}";
			if (File.Exists(path))
            {
				employees.Clear();
				string[] employeesAsString = File.ReadAllLines(path);
				for (int i=0 ; i < employeesAsString.Length ; i++)
                {
					string[] employeesSplit = employeesAsString[i].Split(';');
					string firstName = employeesSplit[0].Substring(employeesSplit[0].IndexOf(':') + 1);
					string lastName = employeesSplit[1].Substring(employeesSplit[1].IndexOf(':') + 1);
					string email = employeesSplit[2].Substring(employeesSplit[2].IndexOf(':') + 1);
					DateTime birthDay = DateTime.Parse(employeesSplit[3].Substring(employeesSplit[3].IndexOf(':') + 1));
					double hourlyRate = double.Parse(employeesSplit[4].Substring(employeesSplit[4].IndexOf(':') + 1));
					string employeeType = employeesSplit[5].Substring(employeesSplit[5].IndexOf(':') + 1);

					Employee employee = null;

					switch(employeeType)
                    {
						case "1":
							employee = new Employee(firstName, lastName, email, birthDay, hourlyRate);
							break;
						case "2":
							employee = new Manager(firstName, lastName, email, birthDay, hourlyRate);
							break;
						case "3":
							employee = new StoreManager(firstName, lastName, email, birthDay, hourlyRate);
							break;
						case "4":
							employee = new Researcher(firstName, lastName, email, birthDay, hourlyRate);
							break;
						case "5":
							employee = new JuniorResearcher(firstName,lastName, email, birthDay, hourlyRate);
							break;
                    }

					employees.Add(employee);
                }
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("Loading success");
				Console.ResetColor();

			}
		}

		internal static void ViewAllEmployees(List<Employee> employees)
        {
			for(int i = 0; i < employees.Count; i++)
            {
				employees[i].DisplayEmployeeDetails();
            }
        }

	}
}
