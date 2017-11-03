using System.ComponentModel.DataAnnotations;

namespace ModernWallet.Models
{
    public class FeedbackModel:BaseForm
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter valid e-mail address")]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
