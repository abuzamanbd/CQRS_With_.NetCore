using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer.Interface;
using DataLayer.Model;
using DataLayer.UnitOfWork;
using MediatR;

namespace BusinessLayer.Command
{
    public class CreateProductCommand: IRequest<Product>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public CreateProductCommand(string name, string description, decimal price)
        {
            ProductName = name;
            Description = description;
            Price = price;
        }

        public class CreateProductCommandHandaler: IRequestHandler<CreateProductCommand, Product>
        {
            private readonly IProductRepository _productRepository;
            private readonly IUnitOfWork _unitOfWork;

            public CreateProductCommandHandaler(IProductRepository productRepository, IUnitOfWork unitOfWork)
            {
                _productRepository = productRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product()
                {
                    ProductName = request.ProductName, 
                    Description = request.Description, 
                    Price = request.Price
                };

                await _productRepository.CreateAsync(product);
                await _unitOfWork.Commit();

                return product;
            }
        }
    }
}
