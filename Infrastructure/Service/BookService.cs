using System;
using Dapper;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interface;

namespace Infrastructure.Service;


public class BookService : IBookService
{
    private DataContext context = new DataContext();

    public BookService(DataContext context)
    {
        this.context = context;
    }

    public async Task AddBookAsync(Book book)
    {
        using var connection = context.GetConnection();

        string sql = @"INSERT INTO Books
        (Title, Genre, PublicationYear, TotalCopies, AvailableCopies)
        VALUES (@Title,@Genre,@PublicationYear,@TotalCopies,@AvailableCopies)";

        await connection.ExecuteAsync(sql, book);
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        using var connection = context.GetConnection();

        return (await connection.QueryAsync<Book>("SELECT * FROM Books")).ToList();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        using var connection = context.GetConnection();

        var book = @"SELECT * FROM Books WHERE BookId=@Id";

        return connection.QuerySingleOrDefault<Book>(book, new { Id = id });
    }

    public async Task UpdateBookAsync(Book book)
    {
        using var connection = context.GetConnection();

        string sql = @"UPDATE Books
        SET Title=@Title,
            Genre=@Genre,
            PublicationYear=@PublicationYear,
            TotalCopies=@TotalCopies,
            AvailableCopies=@AvailableCopies
        WHERE BookId=@BookId";

        connection.Execute(sql, book);
    }

    public async Task DeleteBookAsync(int id)
    {
        using var connection = context.GetConnection();

        await connection.ExecuteAsync(
            "DELETE FROM Books WHERE BookId=@Id",
            new { Id = id });
    }
}