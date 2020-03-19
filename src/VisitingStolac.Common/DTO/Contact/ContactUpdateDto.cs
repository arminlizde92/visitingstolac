using System.ComponentModel.DataAnnotations;

namespace VisitingStolac.Common
{
    /// <summary>
    /// dto for updating contact
    /// </summary>
    public class ContactUpdateDto
    {
        /// <summary> Identification number </summary>
        public int Id { get; set; }

        /// <summary> Contact name </summary>
        public string Name { get; set; }

        /// <summary> Contact phone number </summary>
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary> Contact type </summary>
        [Required]
        public ContactType Type { get; set; }

        /// <summary> if contact is active </summary>
        public bool IsActive { get; set; } = true;
    }
}
