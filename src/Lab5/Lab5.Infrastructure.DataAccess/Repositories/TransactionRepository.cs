using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Transactions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Transaction?> CreateTransaction(decimal amount, TransactionType type, long accountId)
    {
        const string sql = """
        insert into transactions (transaction_amount, transaction_type, account_id)
        values
        (:transactionAmount, :transactionType, :accountId);
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        await using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("transactionAmount", amount)
            .AddParameter("transactionType", type)
            .AddParameter("accountId", accountId);

        int reader = await command.ExecuteNonQueryAsync();

        if (reader == 0)
            return null;

        return new Transaction(amount, type, accountId);
    }

    public async IAsyncEnumerable<Transaction> GetTransactionsByAccountIdAsync(long accountId)
    {
        const string sql = """
        select transaction_id, transaction_amount, transaction_type, account_id
        from transactions
        where account_id = :accountId;
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);
        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            yield return new Transaction(
                Amount: reader.GetDecimal(1),
                Type: await reader.GetFieldValueAsync<TransactionType>(2),
                AccountId: reader.GetInt64(3));
        }
    }
}