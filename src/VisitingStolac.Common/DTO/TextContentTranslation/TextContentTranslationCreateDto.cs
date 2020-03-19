namespace VisitingStolac.Common
{
    /// <summary>
    /// dto for creating text translations
    /// </summary>
    public class TextContentTranslationCreateDto
    {
        /// <summary> text </summary>
        public string Text { get; set; }

        /// <summary> language </summary>
        public Locale Locale { get; set; }
    }
}
