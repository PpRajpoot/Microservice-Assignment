using Shared;
using MassTransit;
using ProductBuisnesslayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBuisnesslayer
{
    public class OrderPlacedConsumer : IConsumer<CartItem>
    {
        private readonly IProductBuisnesslayerService productBLLService;
        public OrderPlacedConsumer(IProductBuisnesslayerService productBLLService)
        {
            this.productBLLService = productBLLService;
        }

        public Task Consume(ConsumeContext<CartItem> context)
        {
            var orderReceived = context.Message;
            var productId = orderReceived.ProductId;
            var orderedQuantity = orderReceived.Quantity;

            //deduct product quantity
            productBLLService.DeductQuantity(productId, orderedQuantity);

            return Task.CompletedTask;
        }

    }
}
