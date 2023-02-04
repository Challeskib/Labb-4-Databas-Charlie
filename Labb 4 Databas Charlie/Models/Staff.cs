using System;
using System.Collections.Generic;

namespace Labb_4_Databas_Charlie.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public int? DeptId { get; set; }

    public int? SalaryId { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Ssn { get; set; }

    public string? Adress { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Position { get; set; }

    public DateTime? HireDate { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual Salary? Salary { get; set; }

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}
