﻿using KeysShop.Core;
using KeysShop.Repository;
using KeysShop.Repository.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeysShop.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UsersRepository usersRepository;
        public UsersController(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await usersRepository.GetUsersAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(UserCreateDto model)
        {
            if (ModelState.IsValid)
            {
                User user = await usersRepository.CreateUserAsync(model.FirstName, model.LastName, model.Password, model.Email);
                return RedirectToAction("Edit", "Users", new { id = user.Id });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            return View(await usersRepository.GetUserAsync(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await usersRepository.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.Roles = await usersRepository.GetRolesAsync();
            return View(await usersRepository.GetUserAsync(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(UserReadDto model, string[] roles)
        {
            if (ModelState.IsValid)
            {
                await usersRepository.UpdateAsync(model, roles);
                return RedirectToAction("Index");
            }
            ViewBag.Roles = await usersRepository.GetRolesAsync();
            return View(model);
        }
    }
}