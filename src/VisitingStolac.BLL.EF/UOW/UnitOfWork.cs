using VisitingStolac.BLL.Abstractions.Repositories;
using VisitingStolac.BLL.Abstractions.UOW;
using VisitingStolac.DAL.Context;

namespace VisitingStolac.BLL.EF.UOW
{
    /// <summary>
    /// Implementation of unit of work pattern
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// pirvate instance of db context
        /// </summary>
        private VisitingStolacDbContext _dbContext;

        /// <summary>
        /// unit of work constructor
        /// </summary>
        /// <param name="dbContext">instance of <see cref="VisitingStolacDbContext"/></param>
        public UnitOfWork(VisitingStolacDbContext dbContext) => _dbContext = dbContext;

        /// <summary> repository of media </summary>
        public IMediaRepository Medias { get; set; }

        /// <summary> repository of contacts </summary>
        public IAdministratorRepository Administrators { get; set; }

        /// <summary> repository of contacts </summary>
        public IContactRepository Contacts { get; set; }

        /// <summary> repository of contribution </summary>
        public IContributionRepository Contributions { get; set; }

        /// <summary> repository of posts </summary>
        public IPostRepository Posts { get; set; }

        /// <summary> repository of subscribers </summary>
        public ISubscriberRepository Subscribers { get; set; }

        /// <summary>
        /// repository for text content translations
        /// </summary>
        public ITextContentTranslationRepository TextContentTranslations { get; set; }

        /// <summary> commits changes </summary>
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
