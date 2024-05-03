using CRUDHistory.Models;

namespace CRUDHistory.Utility.SendingEmails;

public interface IEmailSender{
    Task SendEmailAsync(EmailData emailData);
}