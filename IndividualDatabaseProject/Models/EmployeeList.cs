using System;
using System.Collections.Generic;

namespace IndividualDatabaseProject.Models
{
    public partial class EmployeeList
    {
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Employment { get; set; } = null!;
        public int? YearsOfEmployment { get; set; }
    }
}
