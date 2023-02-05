using System;
using System.Collections.Generic;

namespace IndividualDatabaseProject.Models
{
    public partial class DbStudent
    {
        public DbStudent()
        {
            DbGrades = new HashSet<DbGrade>();
        }

        public int Id { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int Personnummer { get; set; }
        public int? ClassId { get; set; }

        public virtual DbClass? Class { get; set; }
        public virtual ICollection<DbGrade> DbGrades { get; set; }
    }
}
