using System.Net.Mail;
using System.Threading.Tasks;

namespace CarService.WebApplication.Helpers
{
    public static class Mail
    {
        public static async Task SendEmailAsync(string to, string subject, string body)
        {
            var message = new MailMessage
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            message.To.Add(new MailAddress(to)); //replace with valid value
            using (var smtp = new SmtpClient())
            {
                await smtp.SendMailAsync(message);
            }
        }
    }
}