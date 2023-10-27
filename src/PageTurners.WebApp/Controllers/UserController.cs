using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PageTurners.Core.Entities;
using PageTurners.Repositories.DTOs.User;
using PageTurners.Repositories.Interfaces;

namespace PageTurners.WebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await userRepository.GetAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new UserCreateDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateDto model)
        {
            if (ModelState.IsValid)
            {
               var userId = await userRepository.Create(model);
               return RedirectToAction("Edit", new { id = userId });
            }
           return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var userUpdate = (await userRepository.Get(id);
            var user = new UserUpdateDto
            {
                Email = x.Email,
                Name = x.Name,
                Login = x.Login,
                Id = x.Id,
                IsConfirmed = x.IsConfirmed,
                Roles = await userRepository.GetRoles()
            };
            return View(user);
        }

        /*[HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(UserUpdateDto model, string[] roles)
        {
            if (ModelState.IsValid)
            {
                await userRepository.UpdateAsync(model, roles);
                return RedirectToAction("Index");
            }
            ViewBag.Roles = await userRepository.GetRolesAsync();
            return View(model);
        }*/
    }
}
