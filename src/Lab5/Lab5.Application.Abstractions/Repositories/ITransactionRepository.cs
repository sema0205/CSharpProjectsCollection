using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Abstractions.Repositories;

public interface ITransactionRepository
{
    Task<Transaction?> CreateTransaction(decimal amount, TransactionType type, long accountId);

    IAsyncEnumerable<Transaction> GetTransactionsByAccountIdAsync(long accountId);
}