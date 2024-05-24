using Shared;

namespace ProductDetailBuisnessLayer.Interfaces
{
    public interface IProductDetailBuisnessLayerService
    {
        ProductDetail GetProductDetailsById(int id);
        Task<ProductDetail> AddProductDetails(ProductDetail productDetails);
        Task<ProductDetail> RemoveProductDetails(int id);
        List<ProductDetail> GetAllProductDetails();
    }
}
