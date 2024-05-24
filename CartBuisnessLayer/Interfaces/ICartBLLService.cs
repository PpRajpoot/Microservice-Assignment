using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBuisnessLayer.Interfaces
{
    public interface ICartBuisnessLayerService
    {
        List<CartItem> getMyCartItems(int userId);
        Task<CartItem> addToMyCart(int userId, int productId, int quantity);
        CartItem RemovefromMyCart(int userId, int productId);
        void RemoveFromAllCarts(int productId); //only called on deleteProductEvent
    }
}
