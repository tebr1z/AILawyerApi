using System.Net.Mail;
using System.Net;
using HuquqApi.Service.Interfaces;

namespace HuquqApi.Service.Implementations
{
    public class EmailService : IEmailService
    {
        public void SendEmail(List<string> emails, string subject, string body)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("tabrizyh@code.edu.az","Lawyer AI"); 
            foreach (var email in emails)
            {
                mailMessage.To.Add(email);
            }
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com"; 
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("tabrizyh@code.edu.az", "pufa dooz okqc uohf\r\n"); // Google giris password
         

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email Sent Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
