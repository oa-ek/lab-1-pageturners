﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PageTurners.Core.Context;
using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using PageTurners.Repositories.Repos;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;

public class BookRequestController : Controller
{
    private readonly IBookRepository bookRepository;
    private readonly IBookRequestRepository bookRequestRepository;
    public BookRequestController(IBookRepository bookRepository, IBookRequestRepository bookRequestRepository)
    {
        this.bookRepository = bookRepository;
        this.bookRequestRepository = bookRequestRepository;
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
        // Отримати ідентифікатор поточного користувача, який ввійшов до системи
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
                OwnerId = currentUserId 
            };

            bookRequestRepository.Add(bookRequest);

            return RedirectToAction("Index", "Book");
        }
        else
        {
            // Обробка помилки, якщо користувач не ввійшов до системи
            return RedirectToAction("Login"); 
        }
    }


    [HttpPost]
    public async Task<IActionResult> PublishBook(int bookRequestId)
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
}

