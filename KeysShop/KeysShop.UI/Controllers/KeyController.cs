using KeysShop.Core;
using KeysShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KeysShop.UI.Controllers
{
    public class KeyController : Controller
    {
        private readonly KeysRepository keysRepository;
        public KeyController(KeysRepository keysRepository)
        {
            this.keysRepository = keysRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            /*            var list = keysRepository.GetKeys();*/
            List<Key> keys = new List<Key>
            {
                new Key
                {
                    Description = "ключ до бмв",
                    Name = "Ключ BMW"
                },
                new Key
                {
                    Description = "ключ до Ауді",
                    Name = "Ключ Audi"
                }
            };
            return View(keys);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
