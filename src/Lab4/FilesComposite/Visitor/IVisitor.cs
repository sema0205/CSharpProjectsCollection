namespace Itmo.ObjectOrientedProgramming.Lab4.FilesComposite.Visitor;

public interface IVisitor { }

public interface IVisitor<in T> : IVisitor
    where T : IFileSystemComponent
{
    void Visit(T fileSystemComponent);
}