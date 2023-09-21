using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PageTurners.Core.Context;
using Microsoft.AspNetCore.Identity;
using PageTurners.Repositories.Repos;

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

        public IActionResult Edit(int id)
        {
            var book = bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                var existingBook = bookRepository.GetById(model.Id);
                if (existingBook == null)
                {
                    return NotFound();
                }

                // Оновіть дані книги з моделі
                existingBook.Title = model.Title;
                existingBook.Author = model.Author;
                // Оновіть інші поля за необхідністю

                // Збереження змін до бази даних
                bookRepository.Update(existingBook);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var book = bookRepository.GetById(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            bookRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteComment(int commentId)
        {
            var comment = _dbContext.Comment.FirstOrDefault(c => c.Id == commentId);
            if (comment != null)
            {
                _dbContext.Comment.Remove(comment);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Details", new { id = comment.BookId });
        }


        [HttpPost]
        public IActionResult RateBook(int id, int ratingValue)
        {
            int userId = 1; // Встановіть UserId = 1 для неаутентифікованих користувачів

            // Отримайте книгу з бази даних за її ідентифікатором
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound(); // Обробте ситуацію, коли книга не знайдена
            }

            // Створіть новий об'єкт Rating і присвойте йому об'єкти користувача та книги
            var rating = new Rating
            {
                User = _dbContext.Users.FirstOrDefault(u => u.Id == userId),
                Book = book,
                Value = ratingValue
            };

            // Додайте об'єкт Rating до контексту даних і збережіть його в базі даних
            _dbContext.Ratings.Add(rating);
            _dbContext.SaveChanges();

            // Поверніть назад на сторінку деталей книги
            return RedirectToAction("Details", new { id });
        }


    }
}

