using KeysShop.Core;
using KeysShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KeysShop.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly KeysRepository keysRepository;

        public CartController(KeysRepository keysRepository)
        {
            this.keysRepository = keysRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy(int id)
        {
            if (HttpContext.Session.GetObject<List<CartItem>>("cart") == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem { Key = keysRepository.GetKey(id), Quantity = 1 });
                HttpContext.Session.SetObject("cart", cart);
            }
            else
            {
                var cart = HttpContext.Session.GetObject<List<CartItem>>("cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Key = keysRepository.GetKey(id), Quantity = 1 });
                }
                HttpContext.Session.SetObject("cart", cart);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart");
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Key.Id.Equals(id))
                    return i;
            return -1;
        }

    }
}
