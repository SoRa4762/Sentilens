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

            // message setup
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(senderName, senderEmail));
            message.To.Add(new MailboxAddress("", email));

            var body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f4f4f9;
                            margin: 0;
                            padding: 0;
                        }}
                        .email-container {{
                            max-width: 600px;
                            margin: 20px auto;
                            background: #ffffff;
                            border-radius: 8px;
                            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                            padding: 20px;
                        }}
                        .header {{
                            text-align: center;
                            padding: 10px 0;
                            border-bottom: 1px solid #ddd;
                        }}
                        .header h1 {{
                            color: #333;
                            font-size: 24px;
                            margin: 0;
                        }}
                        .content {{
                            padding: 20px;
                            text-align: center;
                        }}
                        .content p {{
                            font-size: 16px;
                            color: #555;
                            margin: 10px 0;
                        }}
                        .otp {{
                            font-size: 24px;
                            font-weight: bold;
                            color: #4CAF50;
                            margin: 20px 0;
                        }}
                        .footer {{
                            text-align: center;
                            font-size: 12px;
                            color: #aaa;
                            margin-top: 20px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='email-container'>
                        <div class='header'>
                            <h1>Reset Password OTP</h1>
                        </div>
                        <div class='content'>
                            <p>Your OTP code is:</p>
                            <div class='otp'>{otp}</div>
                            <p>This code will expire in <strong>10 minutes</strong>.</p>
                            <p>If you did not request this, please ignore this email.</p>
                        </div>
                        <div class='footer'>
                            <p>Sentilens Team</p>
                        </div>
                    </div>
                </body>
                </html>";
            message.Subject = "Reset Password OTP";
            message.Body = new TextPart("html") { Text = body };

            using var client = new SmtpClient();
            await client.ConnectAsync(smtpServer, smtpPort, useSSL);
            await client.AuthenticateAsync(smtpUsername, smtpPassword);

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
