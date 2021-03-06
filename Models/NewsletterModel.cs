﻿using System.ComponentModel.DataAnnotations;

namespace ModernWallet.Models
{
    public class NewsletterModel:BaseForm
    {
        public NewsletterModel()
        {
            ConversationTypeDesc = ConversationType.Newsletter.ToString();
        }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter valid e-mail address")]
        public string Email { get; set; }
    }
}
