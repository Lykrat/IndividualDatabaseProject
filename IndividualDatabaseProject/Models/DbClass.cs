using System;
using System.Collections.Generic;

namespace IndividualDatabaseProject.Models
{
    public partial class DbClass
    {
        public DbClass()
        {
            DbStudents = new HashSet<DbStudent>();
        }

        public int Id { get; set; }
        public string ClassName { get; set; } = null!;

        public virtual ICollection<DbStudent> DbStudents { get; set; }
    }
}
