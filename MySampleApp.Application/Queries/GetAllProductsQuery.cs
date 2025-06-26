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
    public record GetAllProductsQuery() : IRequest<IEnumerable<ProductEntity>>;
    public class GetAllProductsQueryHandler(IProductRepository productRepository)
        : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductEntity>>
    {
        public async Task<IEnumerable<ProductEntity>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProducts();
        }
    }
}
