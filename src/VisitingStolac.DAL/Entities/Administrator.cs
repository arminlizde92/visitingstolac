using System.ComponentModel.DataAnnotations;

namespace VisitingStolac.DAL
{
    /// <summary>
    /// public administrator class
    /// </summary>
    public class Administrator
    {
        /// <summary> Identification number </summary>
        public int Id { get; set; }

        /// <summary> Email </summary>
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        /// <summary> Username </summary>
        public string Username { get; set; }

        /// <summary> password hashed </summary>
        [Required]
        public string Password { get; set; }

        /// <summary> administrator status </summary>
        public bool IsActive { get; set; } = true;
    }
}
