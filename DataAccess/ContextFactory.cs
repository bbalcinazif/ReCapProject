using System;
using System.IO;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleUI
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<CarProjectContext>
    {
        public CarProjectContext CreateDbContext(string[] args)
        {
            Console.WriteLine($"---- CreateDbContext Started ----");
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var contentRootPath = Directory.GetCurrentDirectory();
            Console.WriteLine($"----ContentRootPath : {contentRootPath}");
            Console.WriteLine($"----EnvironmentName : {environmentName}");
            return new CarProjectContext();
        }
    }
}