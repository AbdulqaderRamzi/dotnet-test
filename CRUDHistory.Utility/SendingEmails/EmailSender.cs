using System.Net;
using System.Net.Mail;

using CRUDHistory.Models;

namespace CRUDHistory.Utility.SendingEmails;

public class EmailSender : IEmailSender{
    
    public Task SendEmailAsync(EmailData emailData) {
        var client = new SmtpClient("smtp.office365.com.", 587) {   
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("aboodg9@hotmail.com", "Mr3b59_99KG")
        };
 
        return client.SendMailAsync(
            new MailMessage(from: "aboodg9@hotmail.com",
                to: emailData.Email,
                emailData.Subject,
                emailData.Message
            ));
    }
}