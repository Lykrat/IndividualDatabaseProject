using System;
using System.Collections.Generic;

namespace IndividualDatabaseProject.Models
{
    public partial class DbDepartment
    {
        public DbDepartment()
        {
            DbCourses = new HashSet<DbCourse>();
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; } = null!;

        public virtual ICollection<DbCourse> DbCourses { get; set; }
    }
}
