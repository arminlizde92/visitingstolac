using System.ComponentModel.DataAnnotations;

namespace VisitingStolac.DAL
{
    /// <summary>
    /// contribution class
    /// </summary>
    public class Contribution
    {
        /// <summary> Identification number </summary>
        public int Id { get; set; }

        /// <summary> subscriber Identification number </summary>
        [Required]
        public int SubscriberId { get; set; }

        /// <summary> public virtual instance of subscriber </summary>
        public virtual Subscriber Subscriber { get; set; }

        /// <summary> post Identification number </summary>
        [Required]
        public int PostId { get; set; }

        /// <summary> public virtual instance of post </summary>
        public virtual Post Post { get; set; }
    }
}
