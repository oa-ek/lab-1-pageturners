using Microsoft.AspNetCore.Mvc;
using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PageTurners.Repositories.Interfaces;

namespace PageTurners.WebApp.Controllers
{
    public class BookManagementController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookManagementController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                // код для збереження книги в базу даних через репозиторій
                _bookRepository.Add(book);
                return RedirectToAction("Index", "Book");
            }
            return View("AddBook");
        }
    }
}