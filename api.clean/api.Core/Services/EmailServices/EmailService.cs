using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendOTPEmail(string email, string otp)
        {
            // IConfig setup
            var emailSettings = _configuration.GetSection("EmailSettings");

            // Smtp setup - appsettings.json
            var smtpServer = emailSettings["SmtpServer"];
            var smtpPort = int.Parse(emailSettings["SmtpPort"]);
            var smtpUsername = emailSettings["SmtpUsername"];
            var smtpPassword = emailSettings["SmtpPassword"];
            var senderEmail = emailSettings["SenderEmail"];
            var senderName = emailSettings["SenderName"];
            var useSSL = bool.Parse(emailSettings["UseSSL"]);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(senderName, senderEmail));
            message.To.Add(new MailboxAddress("", email));

            var body = $"Your OTP code is: {otp}\nThis code will expire in 10 minutes.";
            message.Body = new TextPart("plain") { Text = body };

            using var client = new SmtpClient();
            await client.ConnectAsync(smtpServer, smtpPort, useSSL);
            await client.AuthenticateAsync(smtpUsername, smtpPassword);

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
