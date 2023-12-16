using Lab5.Application.Contracts.Admins;
using Lab5.Application.Models.Admins;

namespace Lab5.Application.Admins;

public class CurrentAdminManager : ICurrentAdminService
{
    public Admin? Admin { get; set; }
}