using MediatR;
using MySampleApp.Application.Commands;
using MySampleApp.Domain.Entities;
using MySampleApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Application.Queries
{
    public class GetExternalProductDataQuery : IRequest<dynamic>;
    {
    }
}
