using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PageTurners.WebApp.Controllers
{
    public class UserBookController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserBookRepository _userBookRepository;

        public UserBookController(UserManager<User> userManager, IUserBookRepository userBookRepository)
        {
            _userManager = userManager;
            _userBookRepository = userBookRepository;
        }

        [HttpPost]
        [Authorize] 
        public async Task<IActionResult> LikeBook(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
           
           _userBookRepository.AddLikedBook(currentUser.Id, id);

            
            return RedirectToAction("Index", "Home"); 
        }
    }
}
