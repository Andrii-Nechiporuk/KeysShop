using KeysShop.Core;
using KeysShop.Repository;
using KeysShop.Repository.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KeysShop.UI.Controllers
{
    public class KeyController : Controller
    {
        private readonly KeysRepository keysRepository;
        private readonly BrandRepository brandsRepository;

        public KeyController(KeysRepository keysRepository, BrandRepository brandRepository)
        {
            this.keysRepository = keysRepository;
            brandsRepository = brandRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var keys = keysRepository.GetKeys();
            return View(keys);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(KeyCreateDto keyCreateDto)
        {
            if (ModelState.IsValid)
            {
                var brand = brandsRepository.GetBrandByName(keyCreateDto.Brand);
                if (brand == null)
                {
                    brand = new Brand() { Name = keyCreateDto.Name};
                    brand = await brandsRepository.AddBrandAsync(brand);
                }

                var key = await keysRepository.AddKeyAsync(new Key()
                {
                    Description = keyCreateDto.Description,
                    Price = keyCreateDto.Price,
                    Sale = keyCreateDto.Sale,
                    Frequency = keyCreateDto.Frequency,
                    Count = keyCreateDto.Count,
                    ImgPath = keyCreateDto.ImgPath,
                    IsOriginal = keyCreateDto.IsOriginal,
                    IsKeyless = keyCreateDto.IsKeyless,
                    Brand = brand
                });

                return RedirectToAction("Edit", "Key", new { id = key.Id });
            }
            return View(keyCreateDto);
        }
    }
}
