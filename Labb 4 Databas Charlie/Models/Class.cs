using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();

    public static int PrintAllClasses()
    {
        NewSchoolDbContext context = new NewSchoolDbContext();

        var allClasses = context.Classes
            .Where(p => p.ClassId > 0)
            .OrderBy(p => p.ClassId);

        List<Class> existingClasses = new List<Class>();


        //Addar alla existerande klasser till listan
        Console.WriteLine("Existing Classes:");
        foreach (Class item in allClasses)
        {
            existingClasses.Add(item);
        }

        int counter = 0;

        foreach (var item in existingClasses)
        {
            
            Console.WriteLine($"{counter+1}. {item.ClassName}");
            counter++;
        }

        Console.WriteLine("\nWhich class do you want to view?");
        
        int selectedClass;
        selectedClass = int.Parse(Console.ReadLine());

        Class class1 = existingClasses[selectedClass - 1];

        return class1.ClassId;
    }

    public static void GetStudentsOfClass()
    {
        NewSchoolDbContext context = new NewSchoolDbContext();

        Console.WriteLine("Sort by first name (1) or last name (2)?");
        int sortBy = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Sort students by ascending (1) or descending (2) order?");
        int sortOrder = Convert.ToInt32(Console.ReadLine());

        int selectedClass = PrintAllClasses();

        var studentsInClass = context.Students
            .Where(p => p.ClassId == selectedClass);

        //Switch meny som bestämmer hur studenterna skall sorteras
        switch (sortBy)
        {
            case 1:
                switch (sortOrder)
                {
                    case 1:
                        studentsInClass = studentsInClass.OrderBy(p => p.Fname);
                        break;
                    case 2:
                        studentsInClass = studentsInClass.OrderByDescending(p => p.Fname);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Sorting by ascending order by default.");
                        studentsInClass = studentsInClass.OrderBy(p => p.Fname);
                        break;
                }
                break;
            case 2:
                switch (sortOrder)
                {
                    case 1:
                        studentsInClass = studentsInClass.OrderBy(p => p.Lname);
                        break;
                    case 2:
                        studentsInClass = studentsInClass.OrderByDescending(p => p.Lname);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Sorting by ascending order by default.");
                        studentsInClass = studentsInClass.OrderBy(p => p.Lname);
                        break;
                }
                break;
            default:
                Console.WriteLine("Invalid option. Sorting by first name in ascending order by default.");
                studentsInClass = studentsInClass.OrderBy(p => p.Fname);
                break;
        }

        var allClasses = context.Classes
            .Where(p => p.ClassId > 0)
            .OrderBy(p => p.ClassId);

        foreach (var item in allClasses)
        {
            if (item.ClassId == selectedClass)
            {
                Console.WriteLine($"\nStudents in class: {item.ClassName}");
            }
        }
        
        //{ context.Classes.Where(p => p.ClassId == selectedClass)}

        foreach (Student item in studentsInClass)
        {
            Console.WriteLine($"Name: {item.Fname} {item.Lname}");
        }

    }
}