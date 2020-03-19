using System.ComponentModel.DataAnnotations;

namespace VisitingStolac.DAL
{
    /// <summary>
    /// post contact class
    /// </summary>
    public class PostContact
    {
        /// <summary> Identification number </summary>
        public int Id { get; set; }

        [Required]
        /// <summary> post Identification number </summary>
        public int PostId { get; set; }

        /// <summary> virtual instance of post </summary>
        public virtual Post Post { get; set; }

        /// <summary> contact Identification number </summary>
        [Required]
        public int ContactId { get; set; }

        /// <summary> virtual instance of contact </summary>
        public virtual Contact Contact { get; set; }
    }
}
