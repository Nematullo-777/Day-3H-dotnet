using System;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BorrowingsController : ControllerBase
{
    private readonly IBorrowingService _borrowingService;

    public BorrowingsController(IBorrowingService borrowingService)
    {
        _borrowingService = borrowingService;
    }

    [HttpGet]
    public IActionResult GetAllBorrowings()
    {
        return Ok(_borrowingService.GetAllBorrowingsAsync());
    }

    [HttpPost("borrow")]
    public IActionResult BorrowBook(int bookId, int memberId)
    {
        _borrowingService.BorrowBookAsync(bookId, memberId);
        return Ok("Book borrowed");
    }

    [HttpPost("return")]
    public IActionResult ReturnBook(int borrowingId)
    {
        _borrowingService.ReturnBookAsync(borrowingId);
        return Ok("Book returned");
    }
}
