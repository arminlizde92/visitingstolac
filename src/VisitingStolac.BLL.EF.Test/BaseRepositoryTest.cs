using Microsoft.EntityFrameworkCore;
using VisitingStolac.DAL.Context;

namespace VisitingStolac.BLL.EF.Test
{
    /// <summary>
    /// base test class for repositories
    /// </summary>
    public abstract class BaseRepositoryTest
    {
        /// <summary>
        /// protected context options
        /// </summary>
        protected static DbContextOptions<VisitingStolacDbContext> _options;

        /// <summary>
        /// initializes the context options
        /// </summary>
        protected static void InitializeContextOptions()
        {
            _options = new DbContextOptionsBuilder<VisitingStolacDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_test_database").Options;
        } 

        /// <summary>
        /// cleans context options
        /// </summary>
        protected static void CleanContextOptions()
        {
            _options = null;
        }
    }
}
