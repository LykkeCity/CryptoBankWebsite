using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using CryptoBank.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace CryptoBank
{
    public static class EmailSender
    {

        public static IConfigurationRoot Configuration { get; set; }
        private static SmtpClient _Client;

        static EmailSender() {
            _Client = new SmtpClient();
            _Client.UseDefaultCredentials = Boolean.Parse(ApplicationSettings.Configuration["Email:UseDefaultCredentials"]);
            _Client.Host = ApplicationSettings.Configuration["Email:Host"];
            _Client.Port = int.Parse(ApplicationSettings.Configuration["Email:Port"]);
            _Client.EnableSsl = Boolean.Parse(ApplicationSettings.Configuration["Email:EnableSsl"]);

            _Client.Credentials =
                new NetworkCredential(
                    ApplicationSettings.Configuration["Email:Credentials:NetworkCredentials:UserName"],
                    ApplicationSettings.Configuration["Email:Credentials:NetworkCredentials:Password"]);
        }

        public static void SendFeedback(FeedbackModel feedback) {

            _Client.Send(
               ApplicationSettings.Configuration["Email:Credentials:NetworkCredentials:UserName"],
               ApplicationSettings.Configuration["Email:FeedbackRecipient"],
               ApplicationSettings.Configuration["Email:FeedbackSubject"], 
                feedback.Message);
        }

        public static void SendBeta(IHostingEnvironment env, BetaModel beta)
        {
            MailAddress from = new MailAddress(ApplicationSettings.Configuration["Email:Credentials:NetworkCredentials:UserName"], "");
            MailAddress to = new MailAddress(beta.Email, "");

            MailMessage message = new MailMessage(from, to);
           
            message.IsBodyHtml = true;
            message.Subject = ApplicationSettings.Configuration["Email:JoinBetaSubject"];

            message.Body = FileHelper.Load(env, ApplicationSettings.Configuration["Email:TemplatesFolder"], "email-join-beta.html");

            _Client.Send(message);

        }
    }
}
