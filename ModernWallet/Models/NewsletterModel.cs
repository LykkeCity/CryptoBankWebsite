using System.ComponentModel.DataAnnotations;

namespace ModernWallet.Models
{
    public class NewsletterModel:BaseForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
