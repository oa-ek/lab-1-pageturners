using Microsoft.AspNetCore.Mvc;
using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using System.Collections.Generic;
using System.IO;

public class BookRequestController : Controller
{
    private readonly IBookRequestRepository _bookRequestRepository;


    public BookRequestController(IBookRequestRepository bookRequestRepository)
    {
        _bookRequestRepository = bookRequestRepository;
       
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

        

        // Збереження в базу даних
        _bookRequestRepository.Add(bookRequest);

        return RedirectToAction("Index", "Book");

    }

}
