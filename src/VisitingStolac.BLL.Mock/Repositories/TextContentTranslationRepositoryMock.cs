using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitingStolac.BLL.Abstractions.Repositories;
using VisitingStolac.Common;
using VisitingStolac.DAL;

namespace VisitingStolac.BLL.Mock.Repositories
{
    public class TextContentTranslationRepositoryMock : ITextContentTranslationRepository
    {
        /// <summary>
        /// private list of mock translations
        /// </summary>
        private IList<TextContentTranslation> _translations = new List<TextContentTranslation>
        {
            new TextContentTranslation { Id = 1, TextContentId = 1, Text = "Bosanski", Locale = Locale.BOS},
            new TextContentTranslation { Id = 2, TextContentId = 1, Text = "Deutsch", Locale = Locale.DEU}
        };

        /// <summary>
        /// private mock list of text contents
        /// </summary>
        private IList<TextContent> _textContents = new List<TextContent>
        {
            new TextContent { Id = 1, Created = DateTime.Now }
        };

        public Task<int> AddAsync(TextContentTranslationAddDto createDto)
        {
            if(createDto == null)
                throw new ArgumentNullException($"Text Content create dto is empty");

            foreach(TextContentTranslation translation in _translations)
            {
                if (translation.Locale == createDto.Locale)
                    throw new KeyAlreadyExistsException($"Text translation on {createDto.Locale.ToString()} already exists");
            }

            TextContentTranslation newTranslation = new TextContentTranslation() {
                Id = _translations.Count + new Random().Next(9999),
                Locale = createDto.Locale,
                Text = createDto.Text,
                TextContentId = createDto.TextContentId
            };

            _translations.Add(newTranslation);

            return Task.FromResult(newTranslation.Id);
        }

        public Task<int> CreateAsync(TextContentTranslationCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TextContentTranslationDto> UpdateAsync(TextContentTranslationUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
