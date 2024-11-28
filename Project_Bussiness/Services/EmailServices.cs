using MimeKit;
using Project_Bussiness.Handle.HandleEmail;
using Project_Bussiness.IServices;
using Project_Bussiness.Payloads.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly EmailConfiguration _configuration;
        public EmailServices(EmailConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SendEmmail(EmailMessage emailMessage)
        {
            var message = CreateEmailMessage(emailMessage);
            Send(message);
            var recipients = string.Join(", ", message.To);
            return ResponseMessage.GetEmailSuccessMessage(recipients);
        }
        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("email", _configuration.From));

            emailMessage.To.AddRange(message.To);

            emailMessage.Subject = message.Subject;

            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        private void Send(MimeMessage message)
        {
            using var client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com", _configuration.Port, true);
               // client.Connect(_configuration.SmtpClient, _configuration.Port, true);
                client.AuthenticationMechanisms.Remove("XOUTH2");
                client.Authenticate(_configuration.UserName, _configuration.Password);
                client.Send(message);
            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();

            }
        }
    }
}