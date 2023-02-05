using System;
using System.Collections.Generic;

namespace IndividualDatabaseProject.Models
{
    public partial class DbCourseConnection
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual DbCourse Course { get; set; } = null!;
        public virtual DbStudent Student { get; set; } = null!;
    }
}
