using System;
using System.Collections.Generic;

namespace VisitingStolac.DAL
{
    /// <summary>
    /// text content class
    /// </summary>
    public class TextContent
    {
        /// <summary>
        /// identification number
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DateTime of creating text content
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary>
        /// virtual instance of <see cref="IList{TextContentTranslation}"/>
        /// </summary>
        public virtual IList<TextContentTranslation> Translations { get; set; }
    }
}
