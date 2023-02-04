using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public int? StaffId { get; set; }

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual Staff? Staff { get; set; }

    public virtual ICollection<TeacherCourse> TeacherCourses { get; } = new List<TeacherCourse>();

    public static void ViewAllTeachers()
    {
        NewSchoolDbContext context = new NewSchoolDbContext();

        var allTeachers = context.Teachers
            .Where(p => p.TeacherId > 0)
            .Join(context.Staff,
                  teacher => teacher.StaffId,
                  staff => staff.StaffId,
                  (teacher, staff) => new { Teacher = teacher, Staff = staff });

        foreach (var teacher in allTeachers)
        {
            Console.WriteLine("Teacher ID: {0}, Name: {1} {2}", teacher.Teacher.TeacherId, teacher.Staff.Fname, teacher.Staff.Lname);
        }


    }
}
