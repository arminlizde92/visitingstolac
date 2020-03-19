using System;
using System.Collections.Generic;

namespace VisitingStolac.Common
{
    /// <summary>
    /// post dto
    /// </summary>
    public class PostDto
    {
        /// <summary> Identification number </summary>
        public int Id { get; set; }

        /// <summary> title </summary>
        public string Title { get; set; }

        /// <summary> text  </summary>
        public string Text { get; set; }

        /// <summary> time post is created </summary>
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary> time when post is last modified </summary>
        public DateTime Modified { get; set; } = DateTime.Now;

        /// <summary> administrator </summary>
        public string Administrator { get; set; }

        /// <summary> medias </summary>
        public IList<MediaDto> Medias { get; set; }
    }
}
