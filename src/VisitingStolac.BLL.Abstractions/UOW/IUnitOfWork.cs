using VisitingStolac.BLL.Abstractions.Repositories;

namespace VisitingStolac.BLL.Abstractions.UOW
{
    /// <summary>
    /// IUnit of Work abstraction
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary> Gets repository of Media </summary>
        IMediaRepository Medias { get; }

        /// <summary> Gets repository of administrators </summary>
        IAdministratorRepository Administrators { get; }

        /// <summary> Gets repository of contacts </summary>
        IContactRepository Contacts { get; }

        /// <summary> Gets repository of contributions </summary>
        IContributionRepository Contributions { get; }

        /// <summary> Gets repository of posts </summary>
        IPostRepository Posts { get; }

        /// <summary> Gets repository of subscribers </summary>
        ISubscriberRepository Subscribers { get; }

        /// <summary> Gets repository of text content translations </summary>
        ITextContentTranslationRepository TextContentTranslations { get; }

        /// <summary> Commits </summary>
        void Commit();
    }
}
