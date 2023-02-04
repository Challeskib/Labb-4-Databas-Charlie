using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual ICollection<StudentCourse> StudentCourses { get; } = new List<StudentCourse>();

    public virtual ICollection<TeacherCourse> TeacherCourses { get; } = new List<TeacherCourse>();

    public static void GetAllActiveCourses()
    {
        NewSchoolDbContext context = new NewSchoolDbContext();

        //Spara alla staff med StaffId > 0 i allStaff
        var allActiveCourses = context.Courses
            .Where(p => p.Active == true);

        //Print all staff
        foreach (Course item in allActiveCourses)
        {
            Console.WriteLine($"CourseId: {item.CourseId} | Coursename: {item.CourseName} | Active = {item.Active}");
        }

    }

    public static void GetAllNonActiveCourses()
    {
        NewSchoolDbContext context = new NewSchoolDbContext();

        //Spara alla staff med StaffId > 0 i allStaff
        var allNonActiveCourses = context.Courses
            .Where(p => p.Active == false);

        //Print all staff
        foreach (Course item in allNonActiveCourses)
        {
            Console.WriteLine($"CourseId: {item.CourseId} | Coursename: {item.CourseName} | Active = {item.Active}");
        }

    }

}
