namespace Itmo.ObjectOrientedProgramming.Lab4.Path;

public class SimplePath : IPath
{
    public SimplePath(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public string ToStringView()
    {
        return Path;
    }
}