using System;
using System.Collections.Generic;

namespace IndividualDatabaseProject.Models
{
    public partial class DbEmploymentType
    {
        public DbEmploymentType()
        {
            DbEmployees = new HashSet<DbEmployee>();
        }

        public int Id { get; set; }
        public string Employment { get; set; } = null!;

        public virtual ICollection<DbEmployee> DbEmployees { get; set; }
    }
}
