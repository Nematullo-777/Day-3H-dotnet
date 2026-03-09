using System;
using Domain.Entities;

namespace Infrastructure.Interface;

public interface IBookService
{
    Task AddBookAsync(Book book);
    Task<List<Book>> GetAllBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
}
