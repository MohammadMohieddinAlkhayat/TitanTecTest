
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.DAL.Models;

namespace TitanTecTest.DAL.Seed
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
            bool seededPreviously = dbContext.Employees.Any();
            if (!seededPreviously)
            {
                SeedEmployees(dbContext);
            }

        }

        private static void SeedEmployees(ApplicationDbContext db)
        {
            db.Employees.AddRange(
                new List<Employee>()
                {
                new Employee()
                {
                     Name = "Mark Keeling",
                     Department = "IT",
                     CreationTime=DateTime.Now,
                     DateOfBirth=new DateTime(1970, 5, 15),
                     Address="Clifornia",
                     IsActive=true,
              
                },
                new Employee()
                {
                     Name = "John Cole",
                     Department = "Finincial",
                     CreationTime=DateTime.Now,
                     DateOfBirth=new DateTime(1960, 1, 1),
                     Address="Clifornia",
                     IsActive=true,
                }
                });
            db.SaveChanges();


        }
    }
}
