using Labb_4_Databas_Charlie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_Databas_Charlie
{
    internal class Utility
    {

        public static void RunMenu()
        {
            bool isLooping = true;

            while (isLooping)
            {
                Console.Clear();

                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. List all students");
                Console.WriteLine("2. List all students of a certain class");
                Console.WriteLine("3. Add new staff");
                Console.WriteLine("4. View all staffmembers");
                Console.WriteLine("5. Exit program");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Student.GetAllStudents();
                        PressAnyKeyToContinue();
                        break;
                    case 2:
                        Class.GetStudentsOfClass();
                        PressAnyKeyToContinue();
                        break;
                    case 3:
                        //AddNewStaff();
                        PressAnyKeyToContinue();
                        break;
                    case 4:
                        //GetAllStaff();
                        PressAnyKeyToContinue();
                        break;

                    case 5:
                        isLooping = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            }

        }

        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");

            Console.ReadLine();
        }

    }
}
