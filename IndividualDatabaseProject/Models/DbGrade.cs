using System;
using System.Collections.Generic;

namespace IndividualDatabaseProject.Models
{
    public partial class DbGrade
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }
        public DateTime DateTime { get; set; }

        public virtual DbCourse Course { get; set; } = null!;
        public virtual DbStudent Student { get; set; } = null!;
        public virtual DbEmployee Teacher { get; set; } = null!;
    }
}
