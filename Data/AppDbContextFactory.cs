using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public static string GetConnectionString()
        {

            string path = Directory.GetCurrentDirectory();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsetting.json")
                .Build();

            return configuration.GetConnectionString("Local");
        }
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(GetConnectionString());

            return new AppDbContext(optionsBuilder.Options);
        }
    }


