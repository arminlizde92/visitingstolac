using System.Collections.Generic;
using VisitingStolac.Common;

namespace VisitingStolac.DAL
{
    /// <summary>
    /// media group class
    /// </summary>
    public class MediaGroup
    {
        /// <summary>
        /// identification number
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tells if Post/Banner ect..
        /// </summary>
        public MediaGroupType Type { get; set; }

        /// <summary>
        /// virtual list of medias
        /// </summary>
        public virtual IList<Media> Medias { get; set; }
    }
}
