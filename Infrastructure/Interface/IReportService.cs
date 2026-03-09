using System;
using Domain.Entities;

namespace Infrastructure.Interface;

public interface IReportService
{
    Task<object> GetMostPopularBookAsync();

    Task<object> GetMostActiveMemberAsync();

    Task<int> GetTotalBorrowedBooksAsync();

    Task<decimal> GetAverageFineAsync();

    Task<List<object>> GetBooksNotReturnedAsync();

    Task<List<Book>> GetBooksWithoutAvailableCopiesAsync();

    Task<int> GetBooksNeverBorrowedAsync();

    Task<int> GetMembersWithBorrowingsAsync();

    Task<object> GetMostPopularGenreAsync();

    Task<object> GetFirstMemberWithOverdueAsync();

    Task<List<object>> GetTop5MembersAsync();

    Task<List<object>> GetBooksBorrowedMoreThan5TimesAsync();

    Task<object> GetTotalFinesAsync();

    Task<int> GetOverdueReturnedBooksCountAsync();

    Task<List<object>> GetMembersWhoPaidFineAsync();
}
