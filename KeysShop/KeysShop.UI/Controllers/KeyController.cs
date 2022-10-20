using KeysShop.Core;
using KeysShop.Repository;
using KeysShop.Repository.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Brands = brandsRepository.GetBrands();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(KeyCreateDto keyCreateDto, string brands)
        {
            ViewBag.Brands = brandsRepository.GetBrands();
            if (ModelState.IsValid)
            {
                var brand = brandsRepository.GetBrandByName(brands);
                if (brand == null)
                {
                    brand = new Brand() { Name = brands };
                    brand = await brandsRepository.AddBrandAsync(brand);
                }

                var key = await keysRepository.AddKeyAsync(new Key()
                {
                    Name = keyCreateDto.Name,
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Brands = brandsRepository.GetBrands();
            return View( await keysRepository.GetKeyDto(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(KeyCreateDto model, string brands)
        {
            if (ModelState.IsValid)
            {
                await keysRepository.UpdateAsync(model, brands);
                return RedirectToAction("Index");
            }
            ViewBag.Brands = brandsRepository.GetBrands();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await keysRepository.GetKeyDto(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await keysRepository.DeleteKeyAsync(id);
            return RedirectToAction("Index");
        }
    }
}
