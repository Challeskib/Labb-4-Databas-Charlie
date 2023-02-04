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
}
