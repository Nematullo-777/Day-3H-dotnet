using System;
using Npgsql;

namespace Infrastructure.Context;

public class DataContext
{
    private const string connectionString = @"Host=localhost;
                                            Port=5432;
                                            Username=postgres;
                                            Database=Library_db;
                                            Password=nemat1409;";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
}
