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
                .Include(b => b.Ratings)
                .ThenInclude(r => r.User)
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            double? averageRating = book.Ratings?.Any() == true ? book.Ratings.Average(r => r.Value) : null;

            book.AverageRating = averageRating;

            _dbContext.SaveChanges();

            return View(book);
        }


        [HttpPost]
        public IActionResult AddComment(int id, string newComment)
        {
            string userId = "1"; 

           
            var comment = new Comments
            {
                BookId = id,
                CommentatorId = userId,
                Comment = newComment,
                Date = DateTime.Now
            };

            _dbContext.Comment.Add(comment);
            _dbContext.SaveChanges();

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

                existingBook.Title = model.Title;
                existingBook.Author = model.Author;
                existingBook.Genre = model.Genre;
                existingBook.Edition = model.Edition;
                existingBook.Desc = model.Desc;
                existingBook.DatePubl = model.DatePubl;

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
            string userId = "1";

       
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound(); 
            }

           
            var rating = new Rating
            {
                User = _dbContext.Users.FirstOrDefault(u => u.Id == userId),
                Book = book,
                Value = ratingValue
            };

          
            _dbContext.Ratings.Add(rating);
            _dbContext.SaveChanges();

            
            return RedirectToAction("Details", new { id });
        }


      


    }
}

