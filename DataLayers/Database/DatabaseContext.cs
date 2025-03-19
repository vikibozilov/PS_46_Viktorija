using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayers.Model;
using Microsoft.EntityFrameworkCore;
using Welcome.Others;

namespace DataLayers.Database
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string SolutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(SolutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source = {databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(x => x.Id).ValueGeneratedOnAdd();

            var user = new DatabaseUser("Stefan", "123132", UserRolesEnum.STUDENT, "121221023", "stefan@mail.bg", 1, DateTime.Now.AddYears(10));
            var user1 = new DatabaseUser("Ivan", "132142", UserRolesEnum.PROFESSOR, "121221120", "ivan@abv.bg", 2, DateTime.Now.AddYears(8));
            var user2 = new DatabaseUser("Stoyan", "321331", UserRolesEnum.ADMIN, "123221011", "stoyan@gmail.com", 3, DateTime.Now.AddYears(5));

            modelBuilder.Entity<DatabaseUser>().HasData(user);
            modelBuilder.Entity<DatabaseUser>().HasData(user1);
            modelBuilder.Entity<DatabaseUser>().HasData(user2);
        }

        public DbSet<DatabaseUser> Users { get; set; }
    }
}