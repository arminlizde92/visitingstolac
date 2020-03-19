using System.ComponentModel.DataAnnotations;

namespace VisitingStolac.Common
{
    public class SubscriberCreateDto
    {
        /// <summary> Email </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
