using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.DAL.Models;

namespace TitanTecTest.DAL
{
    public class ApplicationDbContext : DbContext
    {


        protected readonly IConfiguration Configuration;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../TitanTecTest.API/appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                var connectionString = configuration.GetConnectionString("DatabaseConnection");
                builder.UseSqlServer(connectionString);
                return new ApplicationDbContext(builder.Options);
            }
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeFile> EmployeeFiles { get; set; }

    }
}
