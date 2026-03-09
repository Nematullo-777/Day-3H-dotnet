using System;
using Domain.Entities;

namespace Infrastructure.Interface;

public interface IMemberService
{
    Task AddMemberAsync(Member member);
    Task<List<Member>> GetAllMembersAsync();
    Task<Member> GetMemberByIdAsync(int id);
    Task UpdateMemberAsync(Member member);
    Task DeleteMemberAsync(int id);
}
