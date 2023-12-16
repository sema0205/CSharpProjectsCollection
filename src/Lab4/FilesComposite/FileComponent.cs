using Itmo.ObjectOrientedProgramming.Lab4.FilesComposite.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesComposite;

public class FileComponent : IFileSystemComponent
{
    public FileComponent(string fileName)
    {
        FileName = fileName;
    }

    public string FileName { get; }

    public void Accept(IVisitor visitor)
    {
        if (visitor is IVisitor<FileComponent> v)
            v.Visit(this);
    }
}