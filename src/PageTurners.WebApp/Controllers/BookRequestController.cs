using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PageTurners.Core.Context;
using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using System.Collections.Generic;
using System.IO;

public class BookRequestController : Controller
{
    private readonly IBookRequestRepository _bookRequestRepository;
    private readonly PageTurnersContext _dbContext;

    public BookRequestController(IBookRequestRepository bookRequestRepository, PageTurnersContext dbContext)
    {
        _bookRequestRepository = bookRequestRepository;
        _dbContext = dbContext;
    }

    public IActionResult BookRequests()
    {
        var bookRequests = _dbContext.Requests.ToList();
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
            UserId = 1
        };

        _bookRequestRepository.Add(bookRequest);

        return RedirectToAction("Index", "Book");
    }
}

