using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PageTurners.Core.Context;
using Microsoft.AspNetCore.Identity;

namespace PageTurners.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly PageTurnersContext _dbContext;

        public BookController(IBookRepository bookRepository, PageTurnersContext dbContext)
        {
            this.bookRepository = bookRepository;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(bookRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            var book = _dbContext.Books
               .Include(b => b.Comment) 
                   .ThenInclude(c => c.User)
               .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult AddComment(int id, string newComment)
        {
            int userId = 1; // Встановити UserId = 1 для неаутентифікованих користувачів

            // Збережіть коментар у базі даних
            var comment = new Comments
            {
                BookId = id,
                UserId = userId,
                Comment = newComment,
                Date = DateTime.Now
            };

            _dbContext.Comment.Add(comment);
            _dbContext.SaveChanges();

            // Поверніть назад на сторінку деталей книги
            return RedirectToAction("Details", new { id });
        }


    }
}
