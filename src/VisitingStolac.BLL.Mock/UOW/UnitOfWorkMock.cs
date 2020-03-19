using System;
using VisitingStolac.BLL.Abstractions.Repositories;
using VisitingStolac.BLL.Abstractions.UOW;

namespace VisitingStolac.BLL.Mock.UOW
{
    /// <summary>
    /// unit of work mock
    /// </summary>
    public class UnitOfWorkMock : IUnitOfWork
    {
        /// <summary> repository of media </summary>
        public IMediaRepository Medias { get; set; }

        /// <summary> repository of administrators </summary>
        public IAdministratorRepository Administrators { get; set; }

        /// <summary> repository of contacts </summary>
        public IContactRepository Contacts { get; set; }

        /// <summary> repository of contributions </summary>
        public IContributionRepository Contributions { get; set; }

        /// <summary> repository of posts </summary>
        public IPostRepository Posts { get; set; }

        /// <summary> repository of TextContentTranslations abstraction </summary>
        public ISubscriberRepository Subscribers { get; set; }

        /// <summary> repository of subscribers </summary>
        public ITextContentTranslationRepository TextContentTranslations => throw new NotImplementedException();

        /// <summary>
        /// commit
        /// </summary>
        public void Commit()
        {
            
        }
    }
}
