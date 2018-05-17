using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Webjs.Models;

namespace Webjs
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ModelNewsContext>
    {
        public ModelNewsContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();
            var builder = new DbContextOptionsBuilder<ModelNewsContext>();
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=NewsModel;Trusted_Connection=True;MultipleActiveResultSets=true";
            builder.UseSqlServer(connectionString);
            return new ModelNewsContext(builder.Options);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
