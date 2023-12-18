using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PageTurners.Core.Context;
using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using PageTurners.Repositories.Repos;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
public class BookRequestController : Controller
{
    private readonly IBookRepository bookRepository;
    private readonly IBookRequestRepository bookRequestRepository;
    private readonly IWebHostEnvironment webHostEnvironment;
    public BookRequestController(IBookRepository bookRepository, IBookRequestRepository bookRequestRepository, IWebHostEnvironment webHostEnvironment)
    {
        this.bookRepository = bookRepository;
        this.bookRequestRepository = bookRequestRepository;
        this.webHostEnvironment = webHostEnvironment;
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
    public async Task<IActionResult> Create(BookRequest model, List<int> selectedCategories, IFormFile coverFile)
    {
        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId != null)
        {
            var bookRequest = new BookRequest
            {
                Title = model.Title,
                Author = model.Author,
                DatePubl = model.DatePubl,
                Genre = model.Genre,
                Desc = model.Desc,
                Edition = model.Edition,
                OwnerId = currentUserId,
                CoverFile = coverFile
            };

            if (coverFile != null)
            {
                // Змінити шлях до фотографії книги
                bookRequest.CoverPath = UploadCover(coverFile);
            }

            bookRequestRepository.Add(bookRequest);

            return RedirectToAction("Index", "Book");
        }
        else
        {
            return RedirectToAction("Login");
        }
    }



    [HttpPost]
    public async Task<IActionResult> PublishBook(int bookRequestId, IFormFile coverFile)
    {
        var bookRequest = await bookRequestRepository.GetByIdA(bookRequestId);
        if (bookRequest != null)
        {
            var newBook = new Book
            {
                Title = bookRequest.Title,
                Author = bookRequest.Author,
                Genre = bookRequest.Genre,
                Desc = bookRequest.Desc,
                Edition = bookRequest.Edition,
                DatePubl = bookRequest.DatePubl,
                CoverFile = coverFile
            };

            

            bookRepository.Add(newBook);
            bookRequestRepository.Delete(bookRequestId);

            return RedirectToAction("BookRequests");
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteBookRequest(int bookRequestId)
    {
        var bookRequest = await bookRequestRepository.GetByIdA(bookRequestId);
        if (bookRequest != null)
        {
            bookRequestRepository.Delete(bookRequestId);
            return RedirectToAction("BookRequests");
        }

        return NotFound();
    }

    private string UploadCover(IFormFile coverFile)
    {
        string wwwRootPath = webHostEnvironment.WebRootPath;

        string fileName = Path.GetFileNameWithoutExtension(coverFile.FileName);
        string extension = Path.GetExtension(coverFile.FileName);
        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        string path = Path.Combine(wwwRootPath + "/images/book/", fileName);

        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            coverFile.CopyTo(fileStream);
        }

        return "/images/book/" + fileName;
    }
}

