using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int? TeacherId { get; set; }

    public int? StudentId { get; set; }

    public int? CourseId { get; set; }

    public int? Score { get; set; }

    public DateTime? DateOfGrade { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
