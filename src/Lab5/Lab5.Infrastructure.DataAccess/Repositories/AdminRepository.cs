using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Admins;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Admin?> CreateAdminAsync(string login, string password)
    {
        const string sql = """
        insert into admins
        values
        (:login, :password);
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        await using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("login", login)
            .AddParameter("password", password);

        int reader = await command.ExecuteNonQueryAsync();

        if (reader == 0)
            return null;

        return new Admin(login, password);
    }

    public async Task<Admin?> GetAdminByCredentialsAsync(string login, string password)
    {
        const string sql = """
        select admin_id, password
        from admins
        where admin_id = :login and password = :password;
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        await using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("login", login)
            .AddParameter("password", password);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            return new Admin(
                Login: reader.GetString(0),
                Password: reader.GetString(1));
        }

        return null;
    }
}