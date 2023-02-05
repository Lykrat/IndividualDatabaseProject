using System;
using System.Collections.Generic;

namespace IndividualDatabaseProject.Models
{
    public partial class DbCourse
    {
        public DbCourse()
        {
            DbGrades = new HashSet<DbGrade>();
        }

        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string CourseName { get; set; } = null!;
        public DateTime CourseStart { get; set; }
        public DateTime? CourseEnd { get; set; }
        public int DepartmentId { get; set; }

        public virtual DbDepartment Department { get; set; } = null!;
        public virtual DbEmployee Teacher { get; set; } = null!;
        public virtual ICollection<DbGrade> DbGrades { get; set; }
    }
}
