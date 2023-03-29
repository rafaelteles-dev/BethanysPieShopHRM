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

		internal static void RegisterEmployee()
        {

        }



	}
}
