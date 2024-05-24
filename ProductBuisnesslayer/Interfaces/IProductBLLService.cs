using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBuisnesslayer.Interfaces
{
    public interface IProductBuisnesslayerService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        Product AddProduct(Product product);
        Product RemoveProduct(int id);
        void DeductQuantity(int productId, int quantity);
        Task<ProductDetail> GetProductDetailById(int id);
    }
}
