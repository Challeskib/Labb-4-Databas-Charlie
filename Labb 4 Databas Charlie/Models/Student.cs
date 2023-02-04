using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int? ClassId { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Ssn { get; set; }

    public string? Adress { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual ICollection<StudentCourse> StudentCourses { get; } = new List<StudentCourse>();

    public static void GetAllStudents()
    {
        NewSchoolDbContext context = new NewSchoolDbContext();

        //Deklarerar all studenter som har StudentId
        var allStudents = context.Students
            .Where(p => p.StudentId > 0);

        Console.WriteLine("Sort by first name (1) or last name (2)?");
        int sortBy = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Sort by ascending (1) or descending (2) order?");
        int sortOrder = Convert.ToInt32(Console.ReadLine());

        //Switch meny som bestämmer hur allStudents skall sorteras
        switch (sortBy)
        {
            case 1:
                switch (sortOrder)
                {
                    case 1:
                        allStudents = allStudents.OrderBy(p => p.Fname);
                        break;
                    case 2:
                        allStudents = allStudents.OrderByDescending(p => p.Fname);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Sorting by ascending order by default.");
                        allStudents = allStudents.OrderBy(p => p.Fname);
                        break;
                }
                break;
            case 2:
                switch (sortOrder)
                {
                    case 1:
                        allStudents = allStudents.OrderBy(p => p.Lname);
                        break;
                    case 2:
                        allStudents = allStudents.OrderByDescending(p => p.Lname);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Sorting by ascending order by default.");
                        allStudents = allStudents.OrderBy(p => p.Fname);
                        break;
                }
                break;
            default:
                Console.WriteLine("Invalid option. Sorting by first name in ascending order by default.");
                allStudents = allStudents.OrderBy(p => p.Fname);
                break;


        }
        foreach (Student item in allStudents) //loopar genom allStudents med sorteringarna som användaren valde innan
        {
            Console.WriteLine($"{item.StudentId}. {item.Fname} {item.Lname} | PersonalId: {item.Ssn}" +
                $" | Adress: {item.Adress} | Phone: {item.Phone} | Email: {item.Email}");
        }

    }


}
