using VisitingStolac.Common;

namespace VisitingStolac.DAL
{
    /// <summary>
    /// text content translation class
    /// </summary>
    public class TextContentTranslation
    {
        /// <summary> identification number </summary>
        public int Id { get; set; }

        /// <summary> text content identification number </summary>
        public int TextContentId { get; set; }

        /// <summary> virtual instance of text content </summary>
        public virtual TextContent TextContent { get; set; }

        /// <summary> text </summary>
        public string Text { get; set; }

        /// <summary> language </summary>
        public Locale Locale { get; set; }
    }
}
