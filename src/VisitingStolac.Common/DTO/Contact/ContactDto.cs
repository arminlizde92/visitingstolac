namespace VisitingStolac.Common
{
    /// <summary>
    /// contact dto
    /// </summary>
    public class ContactDto
    {
        /// <summary> contact id </summary>
        public int Id { get; set; }

        /// <summary> Contact email </summary>
        public string Email { get; set; }

        /// <summary> Contact name </summary>
        public string Name { get; set; }

        /// <summary> Contact phone number </summary>
        public string PhoneNumber { get; set; }

        /// <summary> Contact type </summary>
        public ContactType Type { get; set; }

        /// <summary> if contact is active </summary>
        public bool IsActive { get; set; } = true;
    }
}
