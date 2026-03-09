using System;
using Domain.Entities;

namespace Infrastructure.Interface;

public interface IBorrowingService
{
    Task BorrowBookAsync(int bookId, int memberId);
    Task ReturnBookAsync(int borrowingId);
    Task<List<Borrowing>> GetAllBorrowingsAsync();
}
