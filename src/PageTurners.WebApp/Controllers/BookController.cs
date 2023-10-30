using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PageTurners.Core.Context;
using Microsoft.AspNetCore.Identity;
using PageTurners.Repositories.Repos;
using System.Security.Claims;


namespace PageTurners.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly ICommentsRepository commentsRepository;
        private readonly IRatingRepository ratingRepository;
        private readonly IUserRepository userRepository;
        /*private readonly PageTurnersContext _dbContext;*/

        public BookController(IBookRepository bookRepository, 
            ICommentsRepository commentsRepository,
            IRatingRepository ratingRepository,
            IUserRepository userRepository
            /*PageTurnersContext dbContext*/)
        {
            this.bookRepository = bookRepository;
            /*_dbContext = dbContext;*/
            this.commentsRepository = commentsRepository;
            this.ratingRepository = ratingRepository;
            this.userRepository = userRepository;
        }


        public IActionResult Index()
        {
            return View(bookRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            var book = bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            var comment = commentsRepository.GetAllForBook(id);
            var rating = ratingRepository.GetAllForBook(id);

            double? averageRating = book.Ratings?.Any() == true ? book.Ratings.Average(r => r.Value) : null;

            book.AverageRating = averageRating;

            bookRepository.Update(book);

            return View(book);
        }


        [HttpPost]
        public IActionResult AddComment(int id, string newComment)
        {
            string userId;

            // Перевірка, чи користувач авторизований
            if (User.Identity.IsAuthenticated)
            {
               
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            else
            {
                // Користувач не авторизований
                userId = "393763d6-1a19-4c79-ab03-5f6ec6b9b38c"; 
            }

            var comment = new Comments
            {
                BookId = id,
                CommentatorId = userId,
                Comment = newComment,
                Date = DateTime.Now
            };

            commentsRepository.Add(comment);

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
            var comment = commentsRepository.GetById(commentId);
            if (comment != null)
            {
                commentsRepository.Delete(commentId);
            }
            return RedirectToAction("Details", new { id = comment.BookId });
        }


        [HttpPost]
        public async Task<IActionResult> RateBook(int id, int ratingValue)
        {
            if (User.Identity.IsAuthenticated)
            {
                // Отримання ідентифікатора користувача
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var book = bookRepository.GetById(id);

                if (book == null)
                {
                    return NotFound();
                }

                var user = await userRepository.GetAsync(userId);

                var rating = new Rating
                {
                    UserId = user.Id,
                    Book = book,
                    Value = ratingValue
                };

                ratingRepository.Add(rating);

                return RedirectToAction("Details", new { id });
            }
            else
            {
                // Користувач не авторизований - перенаправлення на сторінку входу
                return RedirectToAction("Create", "User");
            }
        }

    }
}

