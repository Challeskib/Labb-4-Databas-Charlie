using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();

    public static void PrintAllClasses()
    {
        NewSchoolDbContext context = new NewSchoolDbContext();

        var allClasses = context.Classes
            .Where(p => p.ClassId > 0)
            .OrderBy(p => p.ClassId);

        

        //Skriver ut all existerande klasser på skolan
        Console.WriteLine("Existing Classes:");
        foreach (Class item in allClasses)
        {
            Console.WriteLine(item.ClassName);
        }

    }

    public static void GetStudentsOfClass()
    {
        NewSchoolDbContext context = new NewSchoolDbContext();

        Console.WriteLine("Sort by first name (1) or last name (2)?");
        int sortBy = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Sort students by ascending (1) or descending (2) order?");
        int sortOrder = Convert.ToInt32(Console.ReadLine());

        PrintAllClasses();

        string selectedClass = string.Empty;

        Console.WriteLine("\nWhich class do you want to view?");
        selectedClass = Console.ReadLine();



        //var studentsInClass = context.Students
        //    .Where(p => p.ClassId == selectedClass);

        //Switch meny som bestämmer hur studenterna skall sorteras
        //switch (sortBy)
        //{
        //    case 1:
        //        switch (sortOrder)
        //        {
        //            case 1:
        //                studentsInClass = studentsInClass.OrderBy(p => p.FirstName);
        //                break;
        //            case 2:
        //                studentsInClass = studentsInClass.OrderByDescending(p => p.FirstName);
        //                break;
        //            default:
        //                Console.WriteLine("Invalid option. Sorting by ascending order by default.");
        //                studentsInClass = studentsInClass.OrderBy(p => p.FirstName);
        //                break;
        //        }
        //        break;
        //    case 2:
        //        switch (sortOrder)
        //        {
        //            case 1:
        //                studentsInClass = studentsInClass.OrderBy(p => p.LastName);
        //                break;
        //            case 2:
        //                studentsInClass = studentsInClass.OrderByDescending(p => p.LastName);
        //                break;
        //            default:
        //                Console.WriteLine("Invalid option. Sorting by ascending order by default.");
        //                studentsInClass = studentsInClass.OrderBy(p => p.LastName);
        //                break;
        //        }
        //        break;
        //    default:
        //        Console.WriteLine("Invalid option. Sorting by first name in ascending order by default.");
        //        studentsInClass = studentsInClass.OrderBy(p => p.FirstName);
        //        break;
        //}

        //Console.WriteLine($"\nStudents in class {selectedClass}:");
        //foreach (Student item in studentsInClass)
        //{
        //    Console.WriteLine($"Name: {item.FirstName} {item.LastName}");
        //}

    }
}