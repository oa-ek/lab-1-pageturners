using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PageTurners.Core.Context;

namespace PageTurners.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly PageTurnersContext _dbContext;

        public BookController (IBookRepository bookRepository, PageTurnersContext dbContext)
        {
            this.bookRepository=bookRepository;
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
            return View(bookRepository.GetById(id));
        }
    }
}
