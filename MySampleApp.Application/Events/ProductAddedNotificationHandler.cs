using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Application.Events
{
    public class ProductAddedNotificationHandler(ILogger<ProductAddedNotificationHandler> logger)
   : INotificationHandler<ProductAddedNotification>
    {
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            var product = notification.Product;

            var mail = new MailMessage
            {
                From = new MailAddress("sandy79sandeep@gmail.com"),
                Subject = "New Product Added",
                Body = $"Product '{product.Name}' was added with price {product.Price}",
                IsBodyHtml = true
            };

            mail.To.Add("srajendra@innominds.com");

            // SMTP client setup
            using var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("sandy79sandeep@gmail.com", "ikgv ziuj ecvy aiss"),
                EnableSsl = true
            };
              await smtpClient.SendMailAsync(mail, cancellationToken);
            logger.LogInformation("Email sent for product: {ProductName}", product.Name);
        }
    }
}
