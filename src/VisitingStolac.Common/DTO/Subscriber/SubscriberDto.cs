using System;
using System.ComponentModel.DataAnnotations;

namespace VisitingStolac.Common
{
    /// <summary>
    /// subscriber dto
    /// </summary>
    public class SubscriberDto
    {
        /// <summary>
        /// subscriber id
        /// </summary>
        public int Id { get; set; }

        /// <summary> Email </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary> creation date </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary> is subscriber subscribed on news</summary>
        public bool IsSubscribedOnNews { get; set; }

        /// <summary> is subscriber subscribed on posts </summary>
        public bool IsSubscribedOnPosts { get; set; }

        /// <summary> subsriber status </summary>
        public bool IsActive { get; set; }
    }
}
