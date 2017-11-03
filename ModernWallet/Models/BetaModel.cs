using System.ComponentModel.DataAnnotations;

namespace ModernWallet.Models
{
    public class BetaModel:BaseForm
    {
        [Required]
        [EmailAddress(ErrorMessage = "Please enter valid e-mail address")]
        public string Email { get; set; }
    }
}
