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
}

