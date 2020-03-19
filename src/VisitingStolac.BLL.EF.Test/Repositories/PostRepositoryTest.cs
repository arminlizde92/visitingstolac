using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisitingStolac.BLL.EF.Repositories;
using VisitingStolac.Common;
using VisitingStolac.DAL;
using VisitingStolac.DAL.Context;

namespace VisitingStolac.BLL.EF.Test.Repositories
{
    /// <summary>
    /// test class for post repository entity framework
    /// </summary>
    [TestClass]
    public class PostRepositoryTest : BaseRepositoryTest
    {
        /// <summary>
        /// test initialize method
        /// </summary>
        [TestInitialize]
        public void InitializeTest() => InitializeContextOptions();

        /// <summary>
        /// Cleans up the test
        /// </summary>
        [TestCleanup]
        public void TestCleanUp() => CleanContextOptions();

        // test not working properly yet
        public void GenerateData()
        {
            Post post = new Post()
            {
                Id = 1,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Type = PostType.Activity
            };

            using (var context = new VisitingStolacDbContext(_options))
            {
                context.Posts.Add(post);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// creates post asynchronously 
        /// should return a list with or without elements
        /// </summary>
        [TestMethod]
        public void GetAllAsync_Default_ShouldReturnList()
        {
            using (var context = new VisitingStolacDbContext(_options))
            {
                var service = new PostRepository(context);
                PostPagingParametersDto dto = new PostPagingParametersDto
                {
                    Locale = Locale.BOS,
                    PageNumber = 1,
                    PageSize = 10
                };

                var x = service.GetAllAsync(dto).GetAwaiter().GetResult();
                Assert.IsTrue(x != null);
            }
        }

        /// <summary>
        /// test for get latest
        /// </summary>
        [TestMethod]
        public void GetLatestAsync_BHLanguage_ShouldReturnList()
        {
            using (var context = new VisitingStolacDbContext(_options))
            {
                var service = new PostRepository(context);

                var x = service.GetLatestAsync(Locale.BOS).GetAwaiter().GetResult();
                Assert.IsTrue(x != null);
            }
        }

        /// <summary>
        /// test for get method
        /// </summary>
        [TestMethod]
        public void GetByIdAsync_ShouldReturnPost()
        {
            using (var context = new VisitingStolacDbContext(_options))
            {
                var service = new PostRepository(context);

                var x = service.GetByIdAsync(1, Locale.BOS).GetAwaiter().GetResult();
                Assert.IsTrue(x != null);
            }
        }
    }
}
