using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_ear69.Models
{
    public interface IShoppingCartRepository
    {
        IQueryable<ShoppingCart> ShoppingCarts { get; }
        void SaveShoppingCart(ShoppingCart shoppingCart);
    }
}
