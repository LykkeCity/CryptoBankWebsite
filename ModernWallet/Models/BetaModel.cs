using System.ComponentModel.DataAnnotations;

namespace ModernWallet.Models
{
    public class BetaModel:BaseForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
