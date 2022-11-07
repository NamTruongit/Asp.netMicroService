using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Model;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSetting _emailSetting { get; }
        public ILogger<EmailService> _logger { get; }
        public EmailService(IOptions<EmailSetting> emailSettings,ILogger<EmailService> logger)
        {
            _emailSetting = emailSettings.Value;
            _logger = logger;
        }
        public async Task<bool> SendMail(Email email)
        {
            var client = new SendGridClient(_emailSetting.ApiKey);
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;
            var from = new EmailAddress
            {
                Email = _emailSetting.FromAddress,
                Name = _emailSetting.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from,to,subject,emailBody,emailBody);
            var reponse = await client.SendEmailAsync(sendGridMessage);

            _logger.LogInformation("Mail sent");

            if (reponse.StatusCode  == System.Net.HttpStatusCode.Accepted|| reponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            _logger.LogError("Email Sending failed");
            return false;
        }
    }
}
