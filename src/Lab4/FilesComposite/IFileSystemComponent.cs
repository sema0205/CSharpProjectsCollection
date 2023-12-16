using Itmo.ObjectOrientedProgramming.Lab4.FilesComposite.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesComposite;

public interface IFileSystemComponent
{
    void Accept(IVisitor visitor);
}