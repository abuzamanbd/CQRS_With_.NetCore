using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer.Interface;
using DataLayer.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Query
{
    public class GetAllProductsQuery: IRequest<List<Product>>
    {
        public class GetAllProductsQueryHandaler: IRequestHandler<GetAllProductsQuery, List<Product>>
        {
            private readonly IProductRepository _productRepository;

            public GetAllProductsQueryHandaler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                return await _productRepository.QueryAll(null).ToListAsync(cancellationToken);
            }
        }
    }
}
