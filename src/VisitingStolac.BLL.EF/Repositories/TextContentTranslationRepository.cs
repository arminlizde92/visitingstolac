using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitingStolac.BLL.Abstractions.Repositories;
using VisitingStolac.Common;
using VisitingStolac.DAL;
using VisitingStolac.DAL.Context;

namespace VisitingStolac.BLL.EF.Repositories
{
    public class TextContentTranslationRepository : ITextContentTranslationRepository
    {
        /// <summary> private instance of <see cref="VisitingStolacDbContext"/> </summary>
        private VisitingStolacDbContext _context;

        public TextContentTranslationRepository(VisitingStolacDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// adds new translation to content
        /// </summary>
        /// <param name="addDto">instance of <see cref="TextContentTranslationAddDto"/></param>
        /// <returns>id of newly created translation</returns>
        public async Task<int> AddAsync(TextContentTranslationAddDto addDto)
        {
            TextContent textContent = await _context.TextContents.Where(c => c.Id == addDto.TextContentId)
                                                                 .Include(t => t.Translations)
                                                                 .FirstOrDefaultAsync();

            if (textContent == null)
                throw new KeyNotFoundException($"Text Content with id:{addDto.TextContentId} could not be found");

            foreach (var item in textContent.Translations)
            {
                if(item.Locale == addDto.Locale)
                    throw new KeyAlreadyExistsException($"Translation with {addDto.Locale.ToString()} already exists");
            }

            return await CreateTextContentTranslation(addDto.Text, addDto.Locale, addDto.TextContentId);
        }

        /// <summary>
        /// creates a text translation asynchronus, also creates the needed text content
        /// </summary>
        /// <param name="createDto">instance of <see cref="TextContentTranslationCreateDto"/></param>
        /// <returns>id from newly created <see cref="TextContentTranslation"/></returns>
        public async Task<int> CreateAsync(TextContentTranslationCreateDto createDto)
        {
            TextContent textContent = new TextContent();
            await _context.TextContents.AddAsync(textContent);
            await _context.SaveChangesAsync();

            return await CreateTextContentTranslation(createDto.Text, createDto.Locale, textContent.Id);
        }

        /// <summary>
        /// deletes translation async
        /// </summary>
        /// <param name="id">translation id</param>
        public async Task DeleteByIdAsync(int id)
        {
            TextContentTranslation textContentTranslation = await _context.TextContentTranslations.FindAsync(id);

            if (textContentTranslation != null)
            {
                _context.TextContentTranslations.Remove(textContentTranslation);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyAlreadyExistsException($"Text Content translation with id:{id} could not be found");
            }
        }

        /// <summary>
        /// updates text content translation
        /// </summary>
        /// <param name="updateDto">instance of <see cref="TextContentTranslationUpdateDto"/></param>
        /// <returns>instance of <see cref="TextContentTranslationDto"/></returns>
        public async Task<TextContentTranslationDto> UpdateAsync(TextContentTranslationUpdateDto updateDto)
        {
            TextContentTranslation contentTranslation = await _context.TextContentTranslations.FindAsync(updateDto.Id);

            if(contentTranslation == null)
                throw new KeyNotFoundException($"Text Content translation with id:{updateDto.Id} could not be found");

            contentTranslation.Text = updateDto.Text;
            _context.TextContentTranslations.Update(contentTranslation);
            await _context.SaveChangesAsync();

            return new TextContentTranslationDto()
            {
                Id = contentTranslation.Id,
                Locale = contentTranslation.Locale,
                Text = contentTranslation.Text
            };
        }

        /// <summary>
        /// private method for creating text content translation
        /// </summary>
        /// <param name="text">translation text</param>
        /// <param name="locale">translation language</param>
        /// <param name="textContentId">text content id</param>
        /// <returns>id of newly created translation</returns>
        private async Task<int> CreateTextContentTranslation(string text, Locale locale, int textContentId)
        {
            TextContentTranslation translation = new TextContentTranslation
            {
                Text = text,
                Locale = locale,
                TextContentId = textContentId
            };

            await _context.TextContentTranslations.AddAsync(translation);
            await _context.SaveChangesAsync();

            return translation.Id;
        } 
        
    }
}
