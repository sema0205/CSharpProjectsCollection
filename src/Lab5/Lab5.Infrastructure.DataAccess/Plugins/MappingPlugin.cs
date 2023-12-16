using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5.Application.Models.Transactions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<TransactionType>();
    }
}