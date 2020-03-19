namespace VisitingStolac.Common
{
    /// <summary>
    /// text content translation dto
    /// </summary>
    public class TextContentTranslationDto
    {
        /// <summary>
        /// text content translation id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Text content translation text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// text content translation locale
        /// </summary>
        public Locale Locale { get; set; }
    }
}
