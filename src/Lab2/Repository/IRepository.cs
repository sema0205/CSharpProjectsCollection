namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public interface IRepository<out T>
{
    T GetByName(string detailName);
}