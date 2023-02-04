using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string? DeptName { get; set; }

    public virtual ICollection<Staff> Staff { get; } = new List<Staff>();
}
