using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBuisnessLayer.Interfaces
{
    public interface IOrderBuisnessLayerService
    {
        List<Order> getMyOrders(int userId);
        Task<Order> createMyOrder(int userId, int productId, string authToken);
    }
}
