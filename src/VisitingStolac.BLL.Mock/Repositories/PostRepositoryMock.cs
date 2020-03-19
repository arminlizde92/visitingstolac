using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitingStolac.BLL.Abstractions.Repositories;
using VisitingStolac.Common;
using VisitingStolac.DAL;

namespace VisitingStolac.BLL.Mock.Repositories
{
    /// <summary>
    /// post repository mock
    /// </summary>
    public class PostRepositoryMock : IPostRepository
    {
        /// <summary>
        /// private mock post list
        /// </summary>
        private IList<Post> _posts = new List<Post>()
        {
            new Post(){ Id = 1, AdministratorId = 1, Type = PostType.General, MediaGroupId = 1, TextId = 1, TitleId = 2 },
            new Post(){ Id = 2, AdministratorId = 1, Type = PostType.Activity, MediaGroupId = 1, TextId = 1, TitleId = 2 },
            new Post(){ Id = 3, AdministratorId = 1, Type = PostType.Ecology, MediaGroupId = 1, TextId = 1, TitleId = 2 },
            new Post(){ Id = 4, AdministratorId = 1, Type = PostType.Events, MediaGroupId = 1, TextId = 1, TitleId = 2 },
            new Post(){ Id = 5, AdministratorId = 1, Type = PostType.History, MediaGroupId = 1, TextId = 1, TitleId = 2 },
            new Post(){ Id = 6, AdministratorId = 1, Type = PostType.History, MediaGroupId = 1, TextId = 1, TitleId = 2 },
            new Post(){ Id = 7, AdministratorId = 1, Type = PostType.History, MediaGroupId = 2, TextId = 1, TitleId = 2 },
        };

        /// <summary>
        /// private mock list of text contents
        /// </summary>
        private IList<TextContent> _textContents = new List<TextContent>()
        {
            // first used as text
            new TextContent(){ Id = 1 },

            // second used as title
            new TextContent(){ Id = 2 },
        };

        /// <summary>
        /// private list for mocking translations
        /// </summary>
        private IList<TextContentTranslation> _translations = new List<TextContentTranslation>()
        {
            new TextContentTranslation() { Id = 1, TextContentId = 1, Locale = Locale.BOS, Text = "Naslov na Bosanskom jeziku" },
            new TextContentTranslation() { Id = 2, TextContentId = 1, Locale = Locale.ENG, Text = "Title in english language" },
            new TextContentTranslation() { Id = 3, TextContentId = 1, Locale = Locale.DEU, Text = "Überschrieft auf Deutsch" },
            new TextContentTranslation() { Id = 4, TextContentId = 2, Locale = Locale.BOS, Text = "Tekst na Bosanskom jeziku Tekst na Bosanskom jeziku Tekst na Bosanskom jeziku Tekst na Bosanskom jeziku Tekst na Bosanskom jeziku Tekst na Bosanskom jeziku Tekst na Bosanskom jeziku Tekst na Bosanskom jeziku Tekst na Bosanskom jeziku Tekst na Bosanskom jeziku Tekst na Bosanskom jeziku Tekst na Bosanskom jeziku Tekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jezikuTekst na Bosanskom jeziku" },
            new TextContentTranslation() { Id = 5, TextContentId = 2, Locale = Locale.ENG, Text = "Text in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english languageText in english language" },
            new TextContentTranslation() { Id = 6, TextContentId = 2, Locale = Locale.DEU, Text = "Text ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf DeutschText ist jetzt auf Deutsch" },
        };

        /// <summary>
        /// private mock media list
        /// </summary>
        private IList<MediaGroup> _mediaGroups = new List<MediaGroup>()
        {
            new MediaGroup() { Id = 1, Type = MediaGroupType.Post },
            new MediaGroup() { Id = 2, Type = MediaGroupType.Banner },
        };

        /// <summary>
        /// private list for mocking media
        /// </summary>
        private IList<Media> _medias = new List<Media>()
        {
            new Media(){ Id = 1, Type = MediaType.Image, GroupId = 1, Url = "https://www.turmundial.com/wp-content/uploads/2019/03/DSC_0088.jpg" },
            new Media(){ Id = 2, Type = MediaType.Image, GroupId = 1, Url = "https://upload.wikimedia.org/wikipedia/commons/8/84/Stolac_panorama.JPG" },
            new Media(){ Id = 3, Type = MediaType.Image, GroupId = 1, Url = "http://www.stacjabalkany.pl/wp-content/uploads/2017/11/s9v2-Large.jpg" },
            new Media(){ Id = 4, Type = MediaType.Image, GroupId = 1, Url = "https://upload.wikimedia.org/wikipedia/commons/a/ab/Stolac%2C_Inat_Cuprija_%28most_vzdoru%29_z_18._stol.jpg" },
            new Media(){ Id = 5, Type = MediaType.Image, GroupId = 1, Url = "https://previews.123rf.com/images/marinv/marinv1408/marinv140800077/31062395-many-monumental-medieval-tombstones-lie-scattered-in-stolac-herzegovina-these-tombstones-are-specifi.jpg" },
            new Media(){ Id = 6, Type = MediaType.Image, GroupId = 1, Url = "https://naszebalkany.pl/wp-content/uploads/2015/05/Stolac___0827__IMG_3558.jpg" },
            new Media(){ Id = 7, Type = MediaType.Image, GroupId = 1, Url = "http://www.come-enjoy-bosnia.com/data/01_provalije_waterfall.JPG" },
            new Media(){ Id = 9, Type = MediaType.Video, GroupId = 2, Url = "https://www.youtube.com/watch?v=XOddJNhwLeU" }
        };

        /// <summary>
        /// private mock instance of administrator
        /// </summary>
        private Administrator _administrator = new Administrator()
        {
            Email = "armin.lizde@visitstolac.com",
            Id = 1,
            IsActive = true,
            Password = "hehehash",
            Username = "arminlizde92"
        };

        public Task<PostDto> AddTranslationAsync(PostAddTranslationDto postAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(PostCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// mocks getting all posts
        /// </summary>
        /// <param name="pagingParameters">instance of <see cref="PostPagingParametersDto"/></param>
        /// <returns>instance of <see cref="IEnumerable{PostDto}"/></returns>
        public async Task<IEnumerable<PostDto>> GetAllAsync(PostPagingParametersDto pagingParameters)
        {
            return await GetPostByPagingParameters(pagingParameters);
        }

        /// <summary>
        /// mocks getting post by id and language 
        /// </summary>
        /// <param name="id">post id</param>
        /// <param name="locale">post language</param>
        /// <returns>instance of <see cref="PostDto"/></returns>
        public async Task<PostDto> GetByIdAsync(int id, Locale locale)
        {
            Post post = _posts.Where(p => p.Id == id).FirstOrDefault();

            string text = _translations.Where(tr => tr.TextContentId == post.TextId)
                                           .Where(tr => tr.Locale == locale)
                                           .Select(tr => tr.Text).FirstOrDefault();

            string title = _translations.Where(tr => tr.TextContentId == post.TitleId)
                                            .Where(tr => tr.Locale == locale)
                                            .Select(tr => tr.Text).FirstOrDefault();

            List<MediaDto> medias = _medias.Where(m => m.GroupId == post.MediaGroupId).Select(m => new MediaDto()
            {
                GroupId = m.GroupId,
                Id = m.Id,
                Source = m.Source,
                Type = m.Type.ToString(),
                Url = m.Url
            }).ToList();

            return await Task.FromResult(new PostDto()
            {
                Id = post.Id,
                Administrator = _administrator.Username,
                Created = post.Created,
                Modified = post.Modified,
                Text = text,
                Title = title,
                Medias = medias
            });
        }

        /// <summary>
        /// gets 3 latests posts
        /// </summary>
        /// <param name="locale">language</param>
        /// <returns>instance of <see cref="IEnumerable{PostDto}"/></returns>
        public async Task<IEnumerable<PostDto>> GetLatestAsync(Locale locale)
        {
            PostPagingParametersDto pagingParametersDto = new PostPagingParametersDto
            {
                Locale = locale,
                PageNumber = 1,
                PageSize = 3
            };

            return await GetPostByPagingParameters(pagingParametersDto);
        }

        public Task<PostDto> UpdateAsync(PostUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> UpdateTranslationAsync(PostTranslationUpdateDto postTranslationDto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// private method for getting posts
        /// </summary>
        /// <param name="pagingParameters">instance of <see cref="PostPagingParametersDto"/></param>
        /// <returns>instance of <see cref="IEnumerable{PostDto}"/></returns>
        private async Task<IEnumerable<PostDto>> GetPostByPagingParameters(PostPagingParametersDto pagingParameters)
        {
            if (pagingParameters.PageNumber < 1)
                pagingParameters.PageNumber = 1;

            IList<Post> posts = _posts.Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                                      .Take(pagingParameters.PageSize).ToList();

            IList<PostDto> returnPosts = new List<PostDto>();

            foreach (var item in posts)
            {
                string text = _translations.Where(tr => tr.TextContentId == item.TextId)
                                           .Where(tr => tr.Locale == pagingParameters.Locale)
                                           .Select(tr => tr.Text).FirstOrDefault();

                string title = _translations.Where(tr => tr.TextContentId == item.TitleId)
                                            .Where(tr => tr.Locale == pagingParameters.Locale)
                                            .Select(tr => tr.Text).FirstOrDefault();

                List<MediaDto> medias = _medias.Where(m => m.GroupId == item.MediaGroupId).Select(m => new MediaDto()
                {
                    GroupId = m.GroupId,
                    Id = m.Id,
                    Source = m.Source,
                    Type = m.Type.ToString(),
                    Url = m.Url
                }).ToList();

                string administrator = _administrator.Username;

                returnPosts.Add(new PostDto()
                {
                    Id = item.Id,
                    Title = title,
                    Text = text,
                    Administrator = administrator,
                    Medias = medias
                });
            }

            return await Task.FromResult(returnPosts.OrderBy(p => p.Created));
        }
    }
}
