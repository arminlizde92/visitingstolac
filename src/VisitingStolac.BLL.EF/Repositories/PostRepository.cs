using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitingStolac.BLL.Abstractions.Repositories;
using VisitingStolac.Common;
using VisitingStolac.DAL.Context;

namespace VisitingStolac.BLL.EF.Repositories
{
    /// <summary>
    /// implementation of post repository
    /// </summary>
    public class PostRepository : IPostRepository
    {
        /// <summary> private instance of <see cref="VisitingStolacDbContext"/> </summary>
        private VisitingStolacDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">instance of <see cref="VisitingStolacDbContext"/></param>
        public PostRepository(VisitingStolacDbContext context) => _context = context;

        public Task<PostDto> AddTranslationAsync(PostAddTranslationDto postAddDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CreateAsync(PostCreateDto createDto)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets all posts "/>
        /// </summary>
        /// <returns><see cref="IEnumerable{PostDto}</returns>
        public async Task<IEnumerable<PostDto>> GetAllAsync(PostPagingParametersDto pagingParametersDto)
        {
            return await GetPostsByPagingParametrs(pagingParametersDto);
        }

        /// <summary>
        /// Gets 3 latests posts
        /// </summary>
        /// <param name="locale">language</param>
        /// <returns><see cref="IEnumerable{PostDto}</returns>
        public async Task<IEnumerable<PostDto>> GetLatestAsync(Locale locale)
        {
            PostPagingParametersDto pagingParametersDto = new PostPagingParametersDto
            {
                Locale = locale,
                PageNumber = 1,
                PageSize = 3
            };

            return await GetPostsByPagingParametrs(pagingParametersDto);
        }

        /// <summary>
        /// Gets post by id and language
        /// </summary>
        /// <param name="id">post id</param>
        /// <param name="locale">post language</param>
        /// <returns>instance of <see cref="PostDto"/></returns>
        public async Task<PostDto> GetByIdAsync(int id, Locale locale)
        {
            return await _context.Posts.Select(p => new PostDto
            {
                Id = p.Id,
                Title = p.Title.Translations.Where(t => t.Locale == locale).FirstOrDefault().Text,
                Text = p.Text.Translations.Where(t => t.Locale == locale).FirstOrDefault().Text,
                Administrator = p.Administrator.Username,
                Created = p.Created,
                Modified = p.Modified,
                Medias = p.MediaGroup.Medias.Select(m => new MediaDto
                {
                    GroupId = p.MediaGroupId,
                    Id = m.Id,
                    Source = m.Source,
                    Type = m.Type.ToString(),
                    Url = m.Url
                }).ToList()
            }).Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public Task<PostDto> UpdateAsync(PostUpdateDto updateDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<PostDto> UpdateTranslationAsync(PostTranslationUpdateDto postTranslationDto)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// private method for getting posts 
        /// </summary>
        /// <param name="pagingParametersDto">instance of <see cref="PostPagingParametersDto"/></param>
        /// <returns>instance of <see cref="IEnumerable{PostDto}"/></returns>
        private async Task<IEnumerable<PostDto>> GetPostsByPagingParametrs(PostPagingParametersDto pagingParametersDto)
        {
            return await _context.Posts
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title.Translations.Where(t => t.Locale == pagingParametersDto.Locale).FirstOrDefault().Text,
                    Text = p.Text.Translations.Where(t => t.Locale == pagingParametersDto.Locale).FirstOrDefault().Text,
                    Administrator = p.Administrator.Username,
                    Created = p.Created,
                    Modified = p.Modified,
                    Medias = p.MediaGroup.Medias.Select(m => new MediaDto
                    {
                        GroupId = p.MediaGroupId,
                        Id = m.Id,
                        Source = m.Source,
                        Type = m.Type.ToString(),
                        Url = m.Url
                    }).ToList()
                }).OrderBy(p => p.Created).ToListAsync();
        }
    }
}
