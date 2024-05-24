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
    public class OrderPlacedConsumer : IConsumer<Order>
    {
        private readonly ICartBuisnessLayerService cartBLLService;
        private readonly IPublishEndpoint publishEndpoint;
        public OrderPlacedConsumer(ICartBuisnessLayerService cartBLLService, IPublishEndpoint publishEndpoint)
        {
            this.cartBLLService = cartBLLService;
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<Order> context)
        {
            var orderReceived = context.Message;
            var productId = orderReceived.ProductId;
            var myUserId = orderReceived.UserId;

            //removed products for this ID from my cart
            var removedFromCart = cartBLLService.RemovefromMyCart(myUserId, productId);

            //Publish event to deduct quantity from product service as order is placed
            await publishEndpoint.Publish<CartItem>(removedFromCart);

        }
    }
}
