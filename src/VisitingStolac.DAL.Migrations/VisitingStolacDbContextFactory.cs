using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using VisitingStolac.DAL.Context;

namespace VisitingStolac.DAL.Migrations
{
    public class VisitingStolacDbContextFactory : IDesignTimeDbContextFactory<VisitingStolacDbContext>
    {
        /// <summary>
        /// creates db context
        /// </summary>
        /// <param name="args">console arguments</param>
        /// <returns>instance of <see cref="VisitingStolacDbContext"/></returns>
        public VisitingStolacDbContext CreateDbContext(string[] args)
        {
            ConfigurationBuilder cfgBuilder = new ConfigurationBuilder();

            cfgBuilder.AddJsonFile("appSettings.json");
            cfgBuilder.AddJsonFile($"appSettings.development.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = cfgBuilder.Build();

            string connectionString = configuration.GetConnectionString("VisitingStolacDbContext");

            DbContextOptionsBuilder<VisitingStolacDbContext> builder = new DbContextOptionsBuilder<VisitingStolacDbContext>();

            builder.UseSqlServer(connectionString, optons => optons.EnableRetryOnFailure());
            builder.EnableSensitiveDataLogging();

            return new VisitingStolacDbContext(builder.Options);
        }
    }
}
