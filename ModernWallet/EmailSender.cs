using Microsoft.Extensions.Configuration;
using ModernWallet.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace ModernWallet
{
    public static class EmailSender
    {

        public static IConfigurationRoot Configuration { get; set; }

        public static void SendFeedback(FeedbackModel feedback) {

            var client = new SmtpClient();
            client.UseDefaultCredentials = Boolean.Parse(ApplicationSettings.Configuration["Email:UseDefaultCredentials"]);
            client.Host = ApplicationSettings.Configuration["Email:Host"];
            client.Port = int.Parse(ApplicationSettings.Configuration["Email:Port"]);
            client.EnableSsl = Boolean.Parse(ApplicationSettings.Configuration["Email:EnableSsl"]);

            client.Credentials = 
                new NetworkCredential(
                    ApplicationSettings.Configuration["Email:Credentials:NetworkCredentials:UserName"],
                    ApplicationSettings.Configuration["Email:Credentials:NetworkCredentials:Password"]);

            client.Send(
                ApplicationSettings.Configuration["Email:Credentials:NetworkCredentials:UserName"], 
                "dejan.stevanovic@primeholding.com", 
                "Recent Lykke registrations ", 
                feedback.Message);
        }

        public static void SendNewsletter(NewsletterModel newsletter)
        {
            throw new NotImplementedException();
        }
    }
}
