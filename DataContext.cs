using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD2.Data
{
    internal class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Opret database med MSSQL og brug denne connection string
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=UserDB;Trusted_Connection=true");
        }

        // Definere felter i databasen med User.cs
        public DbSet<User>? Users { get; set; }
    }
}
