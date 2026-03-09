using System;
using Domain.Entities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var books = _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = _bookService.GetBookByIdAsync(id);

        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] Book book)
    {
        _bookService.AddBookAsync(book);
        return Ok("Book added successfully");
    }

    [HttpPut]
    public IActionResult UpdateBook([FromBody] Book book)
    {
        _bookService.UpdateBookAsync(book);
        return Ok("Book updated");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        _bookService.DeleteBookAsync(id);
        return Ok("Book deleted");
    }
}
