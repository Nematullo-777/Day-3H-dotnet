using System;
using Dapper;
using Infrastructure.Interface;
using Domain.Entities;
using System.Data;
using Infrastructure.Context;

namespace Infrastructure.Service;

public class MemberService : IMemberService
{
    private DataContext context = new DataContext();
    public MemberService(DataContext context)
    {
        this.context = context;
    }

    public async Task AddMemberAsync(Member member)
    {
        using var connection = context.GetConnection();

        string sql = @"INSERT INTO Members
        (FullName,Phone,Email,MembershipDate)
        VALUES (@FullName,@Phone,@Email,@MembershipDate)";

        await connection.ExecuteAsync(sql, member);
    }

    public async Task<List<Member>> GetAllMembersAsync()
    {
        using var connection = context.GetConnection();

        return (await connection.QueryAsync<Member>("SELECT * FROM Members")).ToList();
    }

    public async Task<Member?> GetMemberByIdAsync(int id)
    {
        using var connection = context.GetConnection();

        var member = @"SELECT * FROM Members WHERE MemberId=@Id";

        var result = await connection.QuerySingleOrDefaultAsync<Member>(member, new { Id = id });
        return result;
    }

    public async Task UpdateMemberAsync(Member member)
    {
        using var connection = context.GetConnection();

        string sql = @"UPDATE Members
        SET FullName=@FullName,
            Phone=@Phone,
            Email=@Email
        WHERE MemberId=@MemberId";

        await connection.ExecuteAsync(sql, member);
    }

    public async Task DeleteMemberAsync(int id)
    {
        using var connection = context.GetConnection();

        await connection.ExecuteAsync(
            "DELETE FROM Members WHERE MemberId=@Id",
            new { Id = id });
    }
}
