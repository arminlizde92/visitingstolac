namespace VisitingStolac.Common
{
    /// <summary>
    /// dto for adding text content translation
    /// </summary>
    public class TextContentTranslationAddDto
    {
        /// <summary> text content identification number </summary>
        public int TextContentId { get; set; }

        /// <summary> text </summary>
        public string Text { get; set; }

        /// <summary> language </summary>
        public Locale Locale { get; set; }
    }
}
