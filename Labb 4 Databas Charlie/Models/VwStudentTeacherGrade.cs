using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class VwStudentTeacherGrade
{
    public int GradeId { get; set; }

    public int TeacherId { get; set; }

    public string? TeacherName { get; set; }

    public string? CourseName { get; set; }

    public int? Score { get; set; }

    public DateTime? DateOfGrade { get; set; }

    public string? StudentName { get; set; }
}
