using System;
using Dapper;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class ReportService : IReportService
{
    private DataContext context = new DataContext();

    public ReportService(DataContext context)
    {
        this.context = context;
    }

    public async Task<object> GetMostPopularBookAsync()
    {
        using var connection = context.GetConnection();

        string sql = @"
        SELECT b.Title, COUNT(*) as BorrowCount
        FROM Borrowings br
        JOIN Books b ON br.BookId = b.BookId
        GROUP BY b.Title
        ORDER BY BorrowCount DESC
        LIMIT 1";
        List<object> result = (await connection.QueryAsync(sql)).ToList();
        return Task.FromResult(result.FirstOrDefault());
    }

    public async Task<object> GetMostActiveMemberAsync()
    {
        using var connection = context.GetConnection();

        string sql = @"
        SELECT m.FullName, COUNT(*) as Total
        FROM Borrowings b
        JOIN Members m ON b.MemberId = m.MemberId
        GROUP BY m.FullName
        ORDER BY Total DESC
        LIMIT 1";
        List<object> result = (await connection.QueryAsync(sql)).ToList();
        return Task.FromResult(result.FirstOrDefault());
    }

    public async Task<int> GetTotalBorrowedBooksAsync()
    {
        using var connection = context.GetConnection();

        return await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM Borrowings");
    }

    public async Task<decimal> GetAverageFineAsync()
    {
        using var connection = context.GetConnection();

        return await connection.ExecuteScalarAsync<decimal>(
            "SELECT AVG(Fine) FROM Borrowings WHERE Fine > 0");
    }

    public async Task<List<object>> GetBooksNotReturnedAsync()
    {
        using var connection = context.GetConnection();

        string sql = @"
        SELECT b.Title, m.FullName, br.BorrowDate
        FROM Borrowings br
        JOIN Books b ON br.BookId = b.BookId
        JOIN Members m ON br.MemberId = m.MemberId
        WHERE br.ReturnDate IS NULL";

        var result = await connection.QueryAsync(sql);

        return  result.ToList();
    }

    public async Task<List<Book>> GetBooksWithoutAvailableCopiesAsync()
    {
        using var connection = context.GetConnection();

        var sql = @"SELECT * FROM Books WHERE AvailableCopies = 0";

        var result = await connection.QueryAsync<Book>(sql);

        return  result.ToList();
    }

    public async Task<int> GetBooksNeverBorrowedAsync()
    {
        using var connection = context.GetConnection();

        return await connection.ExecuteScalarAsync<int>(@"
        SELECT COUNT(*)
        FROM Books
        WHERE BookId NOT IN
        (SELECT DISTINCT BookId FROM Borrowings)");
    }

    public async Task<int> GetMembersWithBorrowingsAsync()
    {
        using var connection = context.GetConnection();

        return await connection.ExecuteScalarAsync<int>(@"
        SELECT COUNT(DISTINCT MemberId)
        FROM Borrowings");
    }

    public async Task<object> GetMostPopularGenreAsync()
    {
        using var connection = context.GetConnection();

        string sql = @"
        SELECT b.Genre, COUNT(*) as Total
        FROM Borrowings br
        JOIN Books b ON br.BookId = b.BookId
        GROUP BY b.Genre
        ORDER BY Total DESC
        LIMIT 1";
        List<object> result = (await connection.QueryAsync(sql)).ToList();
        return Task.FromResult(result.FirstOrDefault());
    }

    public async Task<object> GetFirstMemberWithOverdueAsync()
    {
        using var connection = context.GetConnection();

        string sql = @"
        SELECT m.FullName, br.DueDate, br.ReturnDate
        FROM Borrowings br
        JOIN Members m ON br.MemberId = m.MemberId
        WHERE br.ReturnDate > br.DueDate
        LIMIT 1";
        List<object> result = (await connection.QueryAsync(sql)).ToList();
        return Task.FromResult(result.FirstOrDefault());
    }

    public async Task<List<object>> GetTop5MembersAsync()
    {
        using var connection = context.GetConnection();

        string sql = @"
        SELECT m.FullName, COUNT(*) as Total
        FROM Borrowings br
        JOIN Members m ON br.MemberId = m.MemberId
        GROUP BY m.FullName
        ORDER BY Total DESC
        LIMIT 5";

        var result = await connection.QueryAsync(sql);

        return  result.ToList();
    }

    public async Task<List<object>> GetBooksBorrowedMoreThan5TimesAsync()
    {
        using var connection = context.GetConnection();

        string sql = @"
        SELECT b.Title, COUNT(*) as Total
        FROM Borrowings br
        JOIN Books b ON br.BookId = b.BookId
        GROUP BY b.Title
        HAVING COUNT(*) > 5";

        var result = await connection.QueryAsync(sql);

        return  result.ToList();
    }

    public async Task<object> GetTotalFinesAsync()
    {
        using var connection = context.GetConnection();

        var sql = @"SELECT SUM(Fine) as TotalFine FROM Borrowings";

        List<object> result = (await connection.QueryAsync(sql)).ToList();
        return Task.FromResult(result.FirstOrDefault());
    }

    public async Task<int> GetOverdueReturnedBooksCountAsync()
    {
        using var connection = context.GetConnection();

        return await connection.ExecuteScalarAsync<int>(@"
        SELECT COUNT(*)
        FROM Borrowings
        WHERE ReturnDate > DueDate");
    }

    public async Task<List<object>> GetMembersWhoPaidFineAsync()
    {
        using var connection = context.GetConnection();

        string sql = @"
        SELECT DISTINCT m.FullName, br.Fine
        FROM Borrowings br
        JOIN Members m ON br.MemberId = m.MemberId
        WHERE br.Fine > 0";

        var result = await connection.QueryAsync(sql);

        return  result.ToList();
    }
}
