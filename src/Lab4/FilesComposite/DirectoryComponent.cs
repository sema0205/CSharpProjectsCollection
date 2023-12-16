using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FilesComposite.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesComposite;

public class DirectoryComponent : IFileSystemComponent
{
    public DirectoryComponent(IEnumerable<IFileSystemComponent> fileSystemComponents, string directoryName)
    {
        FileSystemComponents = fileSystemComponents.ToList();
        DirectoryName = directoryName;
    }

    public string DirectoryName { get; }

    public IList<IFileSystemComponent> FileSystemComponents { get; }

    public void Accept(IVisitor visitor)
    {
        if (visitor is IVisitor<DirectoryComponent> v)
            v.Visit(this);
    }
}