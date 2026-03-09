using System;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private IReportService reportService;

    public ReportsController(IReportService reportService)
    {
        reportService = reportService;
    }

    [HttpGet("popular-book")]
    public async Task<IActionResult> GetMostPopularBook()
        => Ok(await reportService.GetMostPopularBookAsync());

    [HttpGet("active-member")]
    public async Task<IActionResult> GetMostActiveMember()
        => Ok(await reportService.GetMostActiveMemberAsync());

    [HttpGet("total-borrowings")]
    public async Task<IActionResult> GetTotalBorrowings()
        => Ok(await reportService.GetTotalBorrowedBooksAsync());

    [HttpGet("average-fine")]
    public async Task<IActionResult> GetAverageFine()
        => Ok(await reportService.GetAverageFineAsync());

    [HttpGet("not-returned")]
    public async Task<IActionResult> GetBooksNotReturned()
        => Ok(await reportService.GetBooksNotReturnedAsync());

    [HttpGet("no-copies")]
    public async Task<IActionResult> GetBooksWithoutCopies()
        => Ok(await reportService.GetBooksWithoutAvailableCopiesAsync());

    [HttpGet("never-borrowed")]
    public async Task<IActionResult> GetBooksNeverBorrowed()
        => Ok(await reportService.GetBooksNeverBorrowedAsync());

    [HttpGet("members-with-borrowings")]
    public async Task<IActionResult> GetMembersWithBorrowings()
        => Ok(await reportService.GetMembersWithBorrowingsAsync());

    [HttpGet("popular-genre")]
    public async Task<IActionResult> GetPopularGenre()
        => Ok(await reportService.GetMostPopularGenreAsync());

    [HttpGet("first-overdue-member")]
    public async Task<IActionResult> GetFirstOverdueMember()
        => Ok(await reportService.GetFirstMemberWithOverdueAsync());

    [HttpGet("top5-members")]
    public async Task<IActionResult> GetTopMembers()
        => Ok(await reportService.GetTop5MembersAsync());

    [HttpGet("books-over-5")]
    public async Task<IActionResult> GetBooksBorrowedMoreThan5Times()
        => Ok(await reportService.GetBooksBorrowedMoreThan5TimesAsync());

    [HttpGet("total-fines")]
    public async Task<IActionResult> GetTotalFines()
        => Ok(await reportService.GetTotalFinesAsync());

    [HttpGet("overdue-count")]
    public async Task<IActionResult> GetOverdueCount()
        => Ok(await reportService.GetOverdueReturnedBooksCountAsync());

    [HttpGet("members-paid-fine")]
    public async Task<IActionResult> GetMembersPaidFine()
        => Ok(await reportService.GetMembersWhoPaidFineAsync());
}