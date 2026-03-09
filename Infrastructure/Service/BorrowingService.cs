using System;
using Dapper;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class BorrowingService : IBorrowingService
{
    private DataContext context = new DataContext();

    public BorrowingService(DataContext context)
    {
        this.context = context;
    }

    public async Task<List<Borrowing>> GetAllBorrowingsAsync()
    {
        using var connection = context.GetConnection();

        return (await connection.QueryAsync<Borrowing>("SELECT * FROM Borrowings")).ToList();
    }

    public async Task BorrowBookAsync(int bookId, int memberId)
    {
        using var connection = context.GetConnection();

        int copies = await connection.ExecuteScalarAsync<int>(
            "SELECT AvailableCopies FROM Books WHERE BookId=@Id",
            new { Id = bookId });

        if (copies <= 0)
        {
            Console.WriteLine("Нет доступных копий");
            return;
        }

        await connection.ExecuteAsync(@"
        INSERT INTO Borrowings
        (BookId,MemberId,BorrowDate,DueDate,Fine)
        VALUES (@BookId,@MemberId,@BorrowDate,@DueDate,0)",
        new
        {
            BookId = bookId,
            MemberId = memberId,
            BorrowDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(7)
        });

        await connection.ExecuteAsync(@"
        UPDATE Books
        SET AvailableCopies = AvailableCopies - 1
        WHERE BookId=@Id", new { Id = bookId });
    }

    public async Task ReturnBookAsync(int borrowingId)
    {
        using var connection = context.GetConnection();

        var borrow = await connection.QuerySingleAsync<Borrowing>(
            "SELECT * FROM Borrowings WHERE BorrowingId=@Id",
            new { Id = borrowingId });

        DateTime returnDate = DateTime.Now;

        decimal fine = 0;

        if (returnDate > borrow.DueDate)
        {
            int daysLate = (returnDate - borrow.DueDate).Days;
            fine = daysLate * 1;
        }

        await connection.ExecuteAsync(@"
        UPDATE Borrowings
        SET ReturnDate=@ReturnDate,
            Fine=@Fine
        WHERE BorrowingId=@Id",
        new { ReturnDate = returnDate, Fine = fine, Id = borrowingId });

        await connection.ExecuteAsync(@"
        UPDATE Books
        SET AvailableCopies = AvailableCopies + 1
        WHERE BookId=@BookId",
        new { borrow.BookId });
    }
}
