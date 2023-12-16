using Lab5.Application.Models.Admins;

namespace Lab5.Application.Contracts.Admins;

public interface ICurrentAdminService
{
    Admin? Admin { get; }
}