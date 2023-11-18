using System;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesComposite.Visitor;

public class SpecificVisitor : IVisitor<DirectoryComponent>, IVisitor<FileComponent>
{
    private readonly string _indent;
    private readonly string _folder;
    private readonly string _file;
    private int _depth;

    public SpecificVisitor(TreeParameters treeParameters)
    {
        _indent = treeParameters.Ident;
        _folder = treeParameters.Folder;
        _file = treeParameters.File;
    }

    public void Visit(DirectoryComponent fileSystemComponent)
    {
        if (fileSystemComponent.DirectoryName == " ") return;
        Console.WriteLine(string.Concat(Enumerable.Repeat(_indent, _depth)) + _folder + fileSystemComponent.DirectoryName);

        _depth++;

        foreach (IFileSystemComponent fileComponent in fileSystemComponent.FileSystemComponents)
        {
            fileComponent.Accept(this);
        }

        _depth--;
    }

    public void Visit(FileComponent fileSystemComponent)
    {
        if (fileSystemComponent.FileName == " ") return;
        Console.WriteLine(string.Concat(Enumerable.Repeat(_indent, _depth)) + _file + fileSystemComponent.FileName);
    }
}