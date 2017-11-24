﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using CryptoBank.Models;
using System;
using System.Net;
using System.Net.Mail;
using CryptoBank.Infrastructure;
using Lykke.SettingsReader;

namespace CryptoBank
{
    public static class EmailSender
    {

        public static IConfigurationRoot Configuration { get; set; }

        private static SmtpClient CreateMailClient()
        {
            var client = new SmtpClient();

            client.UseDefaultCredentials = ApplicationSettings.AppSettings.CryptoBankWebsite.Email.UseDefaultCredentials;
            client.Host = ApplicationSettings.AppSettings.CryptoBankWebsite.Email.Host;
            client.Port = ApplicationSettings.AppSettings.CryptoBankWebsite.Email.Port;
            client.EnableSsl = ApplicationSettings.AppSettings.CryptoBankWebsite.Email.EnableSsl;

            client.Credentials =
                new NetworkCredential(
                    ApplicationSettings.AppSettings.CryptoBankWebsite.Email.Credentials.Username,
                    ApplicationSettings.AppSettings.CryptoBankWebsite.Email.Credentials.Password);

            return client;
        }

        static EmailSender() {
        }

        public static void SendFeedback(FeedbackModel feedback) {

            CreateMailClient().Send(
               ApplicationSettings.AppSettings.CryptoBankWebsite.Email.Credentials.Username,
               ApplicationSettings.AppSettings.CryptoBankWebsite.Email.FeedbackRecipient,
               ApplicationSettings.AppSettings.CryptoBankWebsite.Email.FeedbackSubject, 
                feedback.Message);
        }

        public static void SendBeta(IHostingEnvironment env, BetaModel beta)
        {
            MailAddress from = new MailAddress(ApplicationSettings.AppSettings.CryptoBankWebsite.Email.Credentials.Username, "");
            MailAddress to = new MailAddress(beta.Email, "");

            MailMessage message = new MailMessage(from, to);
           
            message.IsBodyHtml = true;
            message.Subject = ApplicationSettings.AppSettings.CryptoBankWebsite.Email.JoinBetaSubject;

            message.Body = FileHelper.Load(env, ApplicationSettings.AppSettings.CryptoBankWebsite.Email.TemplatesFolder, "email-join-beta.html");

            CreateMailClient().Send(message);

        }
    }
}
