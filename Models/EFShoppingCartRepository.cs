using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_ear69.Models
{
    public class EFShoppingCartRepository : IShoppingCartRepository
    {
        private BookstoreContext context;
        public EFShoppingCartRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<ShoppingCart> ShoppingCarts => context.ShoppingCarts.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveShoppingCart(ShoppingCart shoppingCart)
        {
            context.AttachRange(shoppingCart.Lines.Select(x => x.Book));
            if (shoppingCart.ShoppingCartId ==0)
            {
                context.ShoppingCarts.Add(shoppingCart);
            }
            context.SaveChanges();
        }
    }
}
