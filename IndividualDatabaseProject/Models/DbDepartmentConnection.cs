using System;
using System.Collections.Generic;

namespace IndividualDatabaseProject.Models
{
    public partial class DbDepartmentConnection
    {
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }

        public virtual DbDepartment Department { get; set; } = null!;
        public virtual DbEmployee Teacher { get; set; } = null!;
    }
}
