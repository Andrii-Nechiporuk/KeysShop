/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using KeysShop.Core;
using KeysShop.Repository;

namespace KeysShop.UI.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }

        private KeysShopContext _db;
        private SessionManager _sessionManager;

        public ShoppingCartActions(KeysShopContext db, SessionManager sessionManager)
        {
            _db = db;
            _sessionManager = sessionManager;
        }

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            // Retrieve the product from the database.           
            ShoppingCartId = GetCartId();

            var cartItem = _db.ShoppingCartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.KeyId == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    KeyId = id,
                    CartId = ShoppingCartId,
                    Key = _db.Keys.SingleOrDefault(
                    p => p.Id == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _db.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public string GetCartId()
        {
            return _sessionManager.GetCartId(CartSessionKey); 
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return _db.ShoppingCartItems.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }
    }
}
*/