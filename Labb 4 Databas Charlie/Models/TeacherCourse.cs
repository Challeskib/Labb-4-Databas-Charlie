using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class TeacherCourse
{
    public int TeacherCourseId { get; set; }

    public int? TeacherId { get; set; }

    public int? CourseId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
