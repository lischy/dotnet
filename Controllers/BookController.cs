using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;

public class BookController: Controller
{
    private ApplicationDbContext _db;

    public BookController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index(){
        var books = _db.Books.ToList();
        return View(books);
    }

    public IActionResult Create()
    {
        // var books = _db.Books.ToList();
        return View();
    }
    
    [HttpPost]
    public IActionResult CreateBook(BooksEntity book){
        _db.Books.Add(book);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
}