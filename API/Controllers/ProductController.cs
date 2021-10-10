using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Command;
using BusinessLayer.Query;
using DataLayer.Model;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            return Ok(await Mediator.Send(new CreateProductCommand(product.ProductName, product.Description,
                product.Price)));
        }
    }
}
