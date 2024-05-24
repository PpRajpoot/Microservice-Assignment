using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDataLayer.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> getMyOrders(int userId);
        Order createMyOrder(Order order);
    }
}
