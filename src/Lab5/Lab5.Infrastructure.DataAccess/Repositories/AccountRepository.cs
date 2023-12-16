using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Accounts;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Account?> CreateAccountAsync(long cardNumber, string password)
    {
        const string sql = """
        insert into accounts (account_id, password, balance)
        values
        (:cardNumber, :password, :balance);
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        await using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("cardNumber", cardNumber)
            .AddParameter("password", password)
            .AddParameter("balance", 0);

        int reader = await command.ExecuteNonQueryAsync();

        if (reader == 0)
            return null;

        return new Account(cardNumber, 0, password);
    }

    public async Task<Account?> GetAccountByIdAsync(long accountId)
    {
        const string sql = """
        select account_id, balance, password
        from accounts
        where account_id = :accountId;
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            return new Account(
                CardNumber: reader.GetInt64(0),
                Balance: reader.GetDecimal(1),
                Password: reader.GetString(2));
        }

        return null;
    }

    public async Task<Account?> MakeOperationAsync(long accountId, decimal amount)
    {
        const string sql = """
        update accounts
        set balance = :balanceAmount
        where account_id = :accountId;
        """;

        Account? account = await GetAccountByIdAsync(accountId);

        if (account is null)
            return null;

        decimal updatedBalance = account.Balance + amount;

        if (updatedBalance < 0)
            return null;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);
        command.AddParameter("balanceAmount", updatedBalance);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        return account with { Balance = updatedBalance };
    }

    public async Task<Account?> GetAccountByCredentialsAsync(long cardNumber, string password)
    {
        const string sql = """
        select account_id, balance, password
        from accounts
        where account_id = :cardNumber and password = :password;
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("cardNumber", cardNumber);
        command.AddParameter("password", password);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            return new Account(
                CardNumber: reader.GetInt64(0),
                Balance: reader.GetDecimal(1),
                Password: reader.GetString(2));
        }

        return null;
    }
}