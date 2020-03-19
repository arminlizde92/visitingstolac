using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VisitingStolac.DAL.Context;

namespace VisitingStolac.DAL.Migrations
{
    /// <summary>
    /// needs to be run after adding migration
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
             .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
             .AddJsonFile("appSettings.development.json", optional: false, reloadOnChange: true);

            var factory = new VisitingStolacDbContextFactory();

            using (VisitingStolacDbContext context = factory.CreateDbContext(args))
            {
                Console.WriteLine("Starting migrations...");
                context.Database.Migrate();                
            }

            Console.WriteLine("Completed ...");
            Console.ReadLine();
        }
    }
}
