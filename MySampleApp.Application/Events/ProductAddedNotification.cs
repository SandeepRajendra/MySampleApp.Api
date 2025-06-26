using MediatR;
using MySampleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Application.Events;

public record ProductAddedNotification(ProductEntity Product) : INotification;
