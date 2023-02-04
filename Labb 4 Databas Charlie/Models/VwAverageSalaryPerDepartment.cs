using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class VwAverageSalaryPerDepartment
{
    public string? DeptName { get; set; }

    public decimal? AverageSalary { get; set; }
}
