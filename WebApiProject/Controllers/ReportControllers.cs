using System;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("popular-book")]
    public async Task<IActionResult> GetMostPopularBook()
        => Ok(await _reportService.GetMostPopularBookAsync());

    [HttpGet("active-member")]
    public async Task<IActionResult> GetMostActiveMember()
        => Ok(await _reportService.GetMostActiveMemberAsync());

    [HttpGet("total-borrowings")]
    public async Task<IActionResult> GetTotalBorrowings()
        => Ok(await _reportService.GetTotalBorrowedBooksAsync());

    [HttpGet("average-fine")]
    public async Task<IActionResult> GetAverageFine()
        => Ok(await _reportService.GetAverageFineAsync());

    [HttpGet("not-returned")]
    public async Task<IActionResult> GetBooksNotReturned()
        => Ok(await _reportService.GetBooksNotReturnedAsync());

    [HttpGet("no-copies")]
    public async Task<IActionResult> GetBooksWithoutCopies()
        => Ok(await _reportService.GetBooksWithoutAvailableCopiesAsync());

    [HttpGet("never-borrowed")]
    public async Task<IActionResult> GetBooksNeverBorrowed()
        => Ok(await _reportService.GetBooksNeverBorrowedAsync());

    [HttpGet("members-with-borrowings")]
    public async Task<IActionResult> GetMembersWithBorrowings()
        => Ok(await _reportService.GetMembersWithBorrowingsAsync());

    [HttpGet("popular-genre")]
    public async Task<IActionResult> GetPopularGenre()
        => Ok(await _reportService.GetMostPopularGenreAsync());

    [HttpGet("first-overdue-member")]
    public async Task<IActionResult> GetFirstOverdueMember()
        => Ok(await _reportService.GetFirstMemberWithOverdueAsync());

    [HttpGet("top5-members")]
    public async Task<IActionResult> GetTopMembers()
        => Ok(await _reportService.GetTop5MembersAsync());

    [HttpGet("books-over-5")]
    public async Task<IActionResult> GetBooksBorrowedMoreThan5Times()
        => Ok(await _reportService.GetBooksBorrowedMoreThan5TimesAsync());

    [HttpGet("total-fines")]
    public async Task<IActionResult> GetTotalFines()
        => Ok(await _reportService.GetTotalFinesAsync());

    [HttpGet("overdue-count")]
    public async Task<IActionResult> GetOverdueCount()
        => Ok(await _reportService.GetOverdueReturnedBooksCountAsync());

    [HttpGet("members-paid-fine")]
    public async Task<IActionResult> GetMembersPaidFine()
        => Ok(await _reportService.GetMembersWhoPaidFineAsync());
}