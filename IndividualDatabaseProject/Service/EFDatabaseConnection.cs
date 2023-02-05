using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualDatabaseProject.Service
{
    internal class EFDatabaseConnection : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = LAPTOP-T8D7ORFB;Integrated Security = True;");
        }
    }
}
