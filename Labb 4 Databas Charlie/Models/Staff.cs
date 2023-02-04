using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public int? DeptId { get; set; }

    public int? SalaryId { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Ssn { get; set; }

    public string? Adress { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Position { get; set; }

    public DateTime? HireDate { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual Salary? Salary { get; set; }

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();

    public static void GetAllStaff()
    {
        NewSchoolDbContext context = new NewSchoolDbContext();

        //Spara alla staff med StaffId > 0 i allStaff
        var allStaff = context.Staff
            .Where(p => p.StaffId > 0);

        //Print all staff
        foreach (Staff item in allStaff)
        {
            Console.WriteLine($"{item.StaffId}. {item.Fname} {item.Lname} | PersonalId: {item.Ssn}" +
                $" | Adress: {item.Adress} | Phone: {item.Phone} | Email: {item.Email} | Position: {item.Position}");
        }

    }

    public static void AddNewStaff()
    {
        NewSchoolDbContext context = new NewSchoolDbContext();

        //Skapar nytt objekt av Staff
        Staff newStaff = new Staff()
        {
            DeptId = 0,
            Fname = "",
            Lname = "",
            Ssn = "",
            Adress = "",
            Phone = "",
            Email = "",
            Position = "",
        };

        //user får bestämma:
        Console.WriteLine("Enter department id: ");
        newStaff.DeptId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter first name: ");
        newStaff.Fname = Console.ReadLine();
        Console.WriteLine("Enter last name: ");
        newStaff.Lname = Console.ReadLine();
        Console.WriteLine("Enter personal ID: ");
        newStaff.Ssn = Console.ReadLine();
        Console.WriteLine("Enter address: ");
        newStaff.Adress = Console.ReadLine();
        Console.WriteLine("Enter phone: ");
        newStaff.Phone = Console.ReadLine();
        Console.WriteLine("Enter email: ");
        newStaff.Email = Console.ReadLine();

        //add objektet till DbContext och sen spara
        context.Staff.Add(newStaff);
        context.SaveChanges();
        Console.WriteLine("New staff member added successfully.");

    }

}
