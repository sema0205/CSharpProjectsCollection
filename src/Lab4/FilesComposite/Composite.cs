using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesComposite;

public class Composite
{
    private readonly int _depth;
    private DirectoryComponent _component;

    public Composite(IPath path, int depth)
    {
        _depth = depth;
        var directory = new DirectoryInfo(path.ToStringView());

        DirectoryInfo[] directories = directory.GetDirectories();
        FileInfo[] files = directory.GetFiles();
        _component = new DirectoryComponent(new List<IFileSystemComponent>(), directory.Name);

        foreach (DirectoryInfo directoryInfo in directories)
        {
            _component.FileSystemComponents.Add(MakeComposite(
                new DirectoryComponent(new List<IFileSystemComponent>(), directoryInfo.Name),
                directoryInfo,
                1));
        }

        foreach (FileInfo fileInfo in files)
        {
            _component.FileSystemComponents.Add(new FileComponent(fileInfo.Name));
        }
    }

    public IFileSystemComponent Component => _component;

    public IFileSystemComponent MakeComposite(DirectoryComponent directoryComponent, DirectoryInfo directory, int depth)
    {
        if (depth > _depth)
            return new FileComponent(" ");

        if (directory.GetDirectories().Length == 0 && directory.GetFiles().Length == 0)
            return new DirectoryComponent(new List<IFileSystemComponent>(), directory.Name);

        DirectoryInfo[] directories = directory.GetDirectories();
        FileInfo[] files = directory.GetFiles();
        foreach (FileInfo fileInfo in files)
        {
            directoryComponent.FileSystemComponents.Add(new FileComponent(fileInfo.Name));
        }

        foreach (DirectoryInfo directoryInfo in directories)
        {
            directoryComponent.FileSystemComponents.Add(
                MakeComposite(
                    new DirectoryComponent(new List<IFileSystemComponent>(), directoryInfo.Name),
                    directoryInfo,
                    depth + 1));
        }

        return directoryComponent;
    }
}