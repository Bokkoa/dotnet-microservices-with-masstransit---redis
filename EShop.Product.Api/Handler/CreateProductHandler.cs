using EShop.Insfrastructure.Command.Product;
using EShop.Product.Api.Services;
using MassTransit;
using System.Threading.Tasks;

namespace EShop.Product.Api.Handler
{
    public class CreateProductHandler : IConsumer<CreateProduct>
    {
        private IProductService _service;

        public CreateProductHandler(IProductService productService)
        {
            _service = productService;
        }

        public async Task Consume(ConsumeContext<CreateProduct> context)
        {
            await _service.AddProduct(context.Message);
            await Task.CompletedTask;
        }
    }
}
