using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Data.EntityFramework
{
    public class Task1DbContextFactory
    {
        public class ProjectDbContextFactory : IDesignTimeDbContextFactory<Task1DbContext>
        {
            public Task1DbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("ProjectDb");

                var optionsBuilder = new DbContextOptionsBuilder<Task1DbContext>();
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

                return new Task1DbContext(optionsBuilder.Options);
            }
        }
    }
}