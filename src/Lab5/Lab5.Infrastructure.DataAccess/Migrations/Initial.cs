using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create table accounts
    (
        account_id bigint primary key ,
        balance money not null ,
        password text not null
    );

    create table admins
    (
        admin_id text primary key ,
        password text not null
    );

    create type transaction_type as enum
    (
        'deposit',
        'withdrawal'
    );

    create table transactions
    (
        transaction_id bigint primary key generated always as identity ,
        transaction_amount money not null ,
        transaction_type transaction_type not null ,
        account_id bigint not null references accounts(account_id)
    );

    insert into admins(admin_id, password) VALUES ('admin', 'admin');
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table accounts;
    drop table admins;
    drop table transactions;

    drop type transaction_type;
    """;
}