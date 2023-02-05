using System;
using System.Collections.Generic;

namespace IndividualDatabaseProject.Models
{
    public partial class TotalSalaryDepartment
    {
        public string DepartmentName { get; set; } = null!;
        public decimal? TotalSalary { get; set; }
    }
}
