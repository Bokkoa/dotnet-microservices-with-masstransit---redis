using EShop.Insfrastructure.Command.Product;
using EShop.Insfrastructure.Event.Product;
using System;
using System.Threading.Tasks;

namespace EShop.Product.Api.Services
{
    public interface IProductService
    {
        Task<ProductCreated> GetProduct(string ProductId);
        Task<ProductCreated> AddProduct(CreateProduct product);

    }
}
