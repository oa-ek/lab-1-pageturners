using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PageTurners.Repositories.Interfaces;

namespace PageTurners.WebApp.Controllers
{
    /*[Authorize]*/
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /*[Authorize(Roles = "Admin")]*/
        public IActionResult Index()
        {
            return View(userRepository.GetAll());
        }
    }
}
