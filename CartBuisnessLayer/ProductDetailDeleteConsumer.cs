using CartBuisnessLayer.Interfaces;
using Shared;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBuisnessLayer
{
    public class ProductDetailDeleteConsumer : IConsumer<ProductDetail>
    {
        private readonly ICartBuisnessLayerService cartBLLService;
        public ProductDetailDeleteConsumer(ICartBuisnessLayerService cartBLLService)
        {
            this.cartBLLService = cartBLLService;
        }

        public Task Consume(ConsumeContext<ProductDetail> context)
        {
            var productReceived = context.Message;
            var productId = productReceived.ProductId;

            //removed all products for this ID from all carts
            cartBLLService.RemoveFromAllCarts(productId);

            return Task.CompletedTask;
        }
    }
}
