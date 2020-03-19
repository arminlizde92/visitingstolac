using System.ComponentModel.DataAnnotations;

namespace VisitingStolac.Common
{
    /// <summary>
    /// dto for creating contacts
    /// </summary>
    public class ContactCreateDto
    {
        /// <summary> Contact email </summary>
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        /// <summary> Contact name </summary>
        public string Name { get; set; }

        /// <summary> Contact phone number </summary>
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary> Contact type </summary>
        [Required]
        public ContactType Type { get; set; }
    }
}
