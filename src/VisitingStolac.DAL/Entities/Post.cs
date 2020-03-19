using System;
using System.ComponentModel.DataAnnotations;
using VisitingStolac.Common;

namespace VisitingStolac.DAL
{
    /// <summary>
    /// post class
    /// </summary>
    public class Post
    {
        /// <summary> Identification number </summary>
        public int Id { get; set; }

        /// <summary> title Identification number </summary>
        [Required]
        public int TitleId { get; set; }

        /// <summary> virtual instance of TextContent for Title </summary>
        public virtual TextContent Title { get; set; }

        /// <summary> text Identification number </summary>
        public int TextId { get; set; }

        /// <summary> virtual instance of TextContent for text </summary>
        public virtual TextContent Text { get; set; }

        /// <summary> time post is created </summary>
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary> time when post is last modified </summary>
        public DateTime Modified { get; set; } = DateTime.Now;

        /// <summary> administrator Identification number </summary>
        public int AdministratorId { get; set; }

        /// <summary> virtual instance of administrator </summary>
        public virtual Administrator Administrator { get; set; }

        /// <summary> media group id </summary>
        public int MediaGroupId { get; set; }

        /// <summary> virtual instance of media group </summary>
        public virtual MediaGroup MediaGroup { get; set; }

        /// <summary> type of post </summary>
        public PostType Type { get; set; }
    }
}
