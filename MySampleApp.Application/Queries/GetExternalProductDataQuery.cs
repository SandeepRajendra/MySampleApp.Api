using MediatR;
using MySampleApp.Application.Commands;
using MySampleApp.Domain.Entities;
using MySampleApp.Domain.Interfaces;
using MySampleApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Application.Queries
{
    public class GetExternalProductDataQuery : IRequest<List<ExternalProductData>>;
    public class GetExternalProductDataQueryHandler(IExternalProductRepository externalProductRepository)
        : IRequestHandler<GetExternalProductDataQuery, List<ExternalProductData>>
    {
        public async Task<List<ExternalProductData>> Handle(GetExternalProductDataQuery request, CancellationToken cancellationToken)
        {
            return await externalProductRepository.GetData();
        }
    }
}
