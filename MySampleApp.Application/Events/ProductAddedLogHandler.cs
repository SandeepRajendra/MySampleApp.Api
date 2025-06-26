using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Application.Events
{
    public class ProductAddedLogHandler(ILogger<ProductAddedLogHandler> logger)
   : INotificationHandler<ProductAddedNotification>
    {
        public Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Product logged: {ProductName}", notification.Product.Name);
            return Task.CompletedTask;
        }
    }
}
