using Microsoft.AspNetCore.Identity.UI.Services;

namespace FunlandV3
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Logic to send email when we can set it up
            throw new NotImplementedException();
        }
    }
}
