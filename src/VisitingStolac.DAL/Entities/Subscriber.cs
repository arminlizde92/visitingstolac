using System;
using System.ComponentModel.DataAnnotations;

namespace VisitingStolac.DAL
{
    /// <summary>
    /// subscriber class
    /// </summary>
    public class Subscriber
    {
        /// <summary> Identification number </summary>
        public int Id { get; set; }

        /// <summary> Email </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary> creation date </summary>
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary> is subscriber subscribed on news</summary>
        public bool IsSubscribedOnNews { get; set; } = true;

        /// <summary> is subscriber subscribed on posts </summary>
        public bool IsSubscribedOnPosts { get; set; } = true;

        /// <summary> subsriber status </summary>
        public bool IsActive { get; set; } = true;
    }
}
