using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RecipeCatalog.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Путь к проекту Web (где лежит appsettings.json)
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "RecipeCatalog.Web");

            // Строим конфигурацию
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            // Получаем строку подключения
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Настраиваем DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}