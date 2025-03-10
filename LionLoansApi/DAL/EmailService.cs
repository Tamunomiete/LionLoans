using SendGrid;
using SendGrid.Helpers.Mail;

namespace LionLoansApi.DAL
{
    public class EmailService
    {
        private readonly string _apiKey;

        public EmailService(IConfiguration configuration)
        {
            _apiKey = configuration["SendGrid:ApiKey"];
        }

        public async Task SendOTP(string email, string otp)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress("no-reply@yourapp.com", "Your App");
            var to = new EmailAddress(email);
            var subject = "Your OTP for Verification";
            var plainTextContent = $"Your OTP is: {otp}";
            var htmlContent = $"<strong>Your OTP is: {otp}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
