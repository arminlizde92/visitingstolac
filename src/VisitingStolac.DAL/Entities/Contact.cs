using System.ComponentModel.DataAnnotations;
using VisitingStolac.Common;

namespace VisitingStolac.DAL
{
    /// <summary>
    /// public class for contacts Restaurants/Bars/ ect..
    /// </summary>
    public class Contact
    {
        /// <summary> Identification number </summary>
        public int Id { get; set; }

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

        /// <summary> if contact is active </summary>
        public bool IsActive { get; set; } = true;
    }
}
