using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PageTurners.Core.Context;
using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using PageTurners.Repositories.Repos;
using System.Collections.Generic;
using System.IO;

public class BookRequestController : Controller
{
    private readonly IBookRepository bookRepository;
    private readonly IBookRequestRepository bookRequestRepository;
    /*private readonly PageTurnersContext _dbContext;*/

    public BookRequestController(IBookRequestRepository bookRequestRepository /*PageTurnersContext dbContext*/)
    {
        this.bookRequestRepository = bookRequestRepository;
        /*_dbContext = dbContext;*/
    }

    public IActionResult BookRequests()
    {
        var bookRequests = bookRequestRepository.GetAll();
        return View(bookRequests);
    }

    public IActionResult Create()
    {
        return View("Create");
    }

   /* [HttpPost]
    [Authorize(Roles = "Moderator")]
    public IActionResult PublishBook(int bookId)
    {
        var book = bookRepository.GetById(bookId);

        if (book != null)
        {
            book.IsPublished = true; // Опублікувати книгу
            BookRequestRepository.Update(book); // Позначити зміни
            return RedirectToAction("Index");
        }
        return NotFound();
    }
   */

    [HttpPost]
    public IActionResult Create(BookRequest model, List<int> selectedCategories)
    {
        var bookRequest = new BookRequest
        {
            Title = model.Title,
            Author = model.Author,
            DatePubl = model.DatePubl,
            Genre = model.Genre,
            Desc = model.Desc,
            Edition = model.Edition,
            OwnerId = "1"
        };

        bookRequestRepository.Add(bookRequest);

        return RedirectToAction("Index", "Book");


    }

    [Authorize(Roles = "Moderator")]
    [HttpPost]
    public async Task<IActionResult> PublishBook(int bookRequestId)
    {
        var bookRequest = await bookRequestRepository.GetByIdA(bookRequestId);
        if (bookRequest != null)
        {
            // Створіть новий об'єкт Book з даними з запиту та додайте його до таблиці Books
            var newBook = new Book
            {
                Title = bookRequest.Title,
                Author = bookRequest.Author,
                Genre = bookRequest.Genre,
                Desc = bookRequest.Desc,
                Edition = bookRequest.Edition,
                DatePubl = bookRequest.DatePubl,
                // Додайте інші дані книги за необхідності
            };

            bookRepository.Add(newBook);

            // Видаліть книгу з таблиці BookRequest
            bookRequestRepository.Delete(bookRequestId);

            return RedirectToAction("BookRequests");
        }

        return NotFound();
    }


    // Відхилити книгу
    [HttpPost]
    public async Task<IActionResult> RejectBook(int bookRequestId)
    {
        var bookRequest = await _context.BookRequests.FindAsync(bookRequestId);
        if (bookRequest != null)
        {
            _context.BookRequests.Remove(bookRequest);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("BookRequests"); // Повернення на головну сторінку BookRequest
    }
}

