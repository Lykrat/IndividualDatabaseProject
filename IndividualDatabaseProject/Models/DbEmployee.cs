using System;
using System.Collections.Generic;

namespace IndividualDatabaseProject.Models
{
    public partial class DbEmployee
    {
        public DbEmployee()
        {
            DbCourses = new HashSet<DbCourse>();
            DbGrades = new HashSet<DbGrade>();
        }

        public int Id { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int EmploymentId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Salary { get; set; }

        public virtual DbEmploymentType Employment { get; set; } = null!;
        public virtual ICollection<DbCourse> DbCourses { get; set; }
        public virtual ICollection<DbGrade> DbGrades { get; set; }
    }
}
