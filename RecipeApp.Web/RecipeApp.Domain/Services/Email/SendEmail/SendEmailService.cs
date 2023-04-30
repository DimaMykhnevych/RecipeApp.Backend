using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RecipeApp.Domain.Services.Email.SendEmail
{
    public class SendEmailService : ISendEmailService
    {
        private readonly EmailServiceOptions _emailServiceDetails;
        private readonly ILogger _logger;

        public SendEmailService(IOptions<EmailServiceOptions> options, ILoggerFactory loggerFactory)
        {
            _emailServiceDetails = options.Value;
            _logger = loggerFactory?.CreateLogger(nameof(SendEmailService));
        }

        public async Task SendAccountConfirmationEmail(AppUser user, string url)
        {
            _logger.LogDebug("Sending account confirmation email to {userName}", user.UserName);

            MailAddress addressFrom = new(_emailServiceDetails.EmailAddress, "RecipeApp");
            MailAddress addressTo = new(user.Email);
            MailMessage message = new(addressFrom, addressTo);

            message.Subject = "Account Confirmation";
            message.IsBodyHtml = true;
            string htmlString = @$"<html>
                      <body style='background-color: #f7f1d5; 
                        padding: 15px; border-radius: 15px; 
                        box-shadow: 5px 5px 15px 5px #9F9F9F;
                        font-size: 16px;'>
                      <p>Hello {user.UserName},</p>
                      <p>Please, confirm your account by clicking the following link.</p>
                      <a href={url}>Confirm Account</a>
                         <p>Thank you,<br>-RecipeApp</br></p>
                      </body>
                      </html>
                     ";
            message.Body = htmlString;

            SmtpClient smtp = new("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(_emailServiceDetails.EmailAddress, _emailServiceDetails.Password);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(message);
        }

        public async Task SendStoredIngredientExpirationEmail(AppUser receiver, IEnumerable<StoredIngredient> expiredIngredeints)
        {
            _logger.LogDebug("Sending stored ingredients expiration email to {userName}", receiver.UserName);

            StringBuilder tableRowStringBuilder = new();
            foreach (var expiredIngredient in expiredIngredeints)
            {
                tableRowStringBuilder.AppendLine($@"
                      <tr>
                        <td style='border: 1px solid black'>{expiredIngredient.Ingredient.Name}</td>
                        <td style='border: 1px solid black'>{expiredIngredient.ExpirationDate:g}</td>
                      </tr>                        
                ");
            }

            MailAddress addressFrom = new(_emailServiceDetails.EmailAddress, "RecipeApp");
            MailAddress addressTo = new(receiver.Email);
            MailMessage message = new(addressFrom, addressTo);

            message.Subject = "Stored Ingredients Expiration";
            message.IsBodyHtml = true;
            string htmlString = @$"<html>
                      <body style='background-color: #f7f1d5; 
                        padding: 15px; border-radius: 15px; 
                        box-shadow: 5px 5px 15px 5px #9F9F9F;
                        font-size: 16px;'>
                      <p>Dear {receiver.UserName},</p>
                      <p>The following ingredients will expire soon:</p>
                      <br/>
                      <table style='border: 1px solid black'>
                        <thead>
                           <tr>
                            <th style='border: 1px solid black'>Ingredient Name</th>
                            <th style='border: 1px solid black'>Expiration Date</th>
                          </tr>                           
                        </thead>
                        <tbody>
                           {tableRowStringBuilder}                         
                        </tbody>
                      </table>
                         <p>Thank you,<br>-RecipeApp</br></p>
                      </body>
                      </html>
                     ";
            message.Body = htmlString;


            SmtpClient smtp = new("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(_emailServiceDetails.EmailAddress, _emailServiceDetails.Password);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(message);
        }
    }
}
