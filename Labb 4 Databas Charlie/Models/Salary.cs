using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class Salary
{
    public int SalaryId { get; set; }

    public decimal? Salary1 { get; set; }

    public virtual ICollection<Staff> Staff { get; } = new List<Staff>();
}
