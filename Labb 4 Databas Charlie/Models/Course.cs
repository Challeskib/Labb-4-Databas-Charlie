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
}
