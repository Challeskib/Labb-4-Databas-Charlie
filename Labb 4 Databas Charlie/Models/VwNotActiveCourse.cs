using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class VwNotActiveCourse
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public bool? Active { get; set; }
}
