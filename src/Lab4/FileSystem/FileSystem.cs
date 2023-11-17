using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FilesComposite;
using Itmo.ObjectOrientedProgramming.Lab4.FilesComposite.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class FileSystem : IFileSystem
{
    private readonly string _mode;

    private IPath _globalPath;

    public FileSystem(IPath path, string mode)
    {
        _globalPath = path;
        _mode = mode;
    }

    public CommandExecutionResult TreeGoTo(IPath path)
    {
        string source = path.ToStringView();

        if (!System.IO.Path.IsPathRooted(path.ToStringView()))
            source = System.IO.Path.Combine(new[] { _globalPath.ToStringView(), path.ToStringView() });

        _globalPath = new SimplePath(source);

        return new CommandExecutionResult.Success();
    }

    public CommandExecutionResult TreeList(int depth)
    {
        var composite = new Composite(_globalPath, depth);
        var visitor = new SpecificVisitor();
        composite.Component.Accept(visitor);
        return new CommandExecutionResult.Success();
    }

    public CommandExecutionResult FileShow(IPath path, string mode)
    {
        if (mode != "console")
            return new CommandExecutionResult.Failed();

        if (System.IO.Path.IsPathRooted(path.ToStringView()))
        {
            Console.WriteLine(File.ReadAllText(path.ToStringView()));
            return new CommandExecutionResult.Success();
        }

        Console.WriteLine(File.ReadAllText(System.IO.Path.Combine(new[] { _globalPath.ToStringView(), path.ToStringView() })));
        return new CommandExecutionResult.Success();
    }

    public CommandExecutionResult FileMove(IPath sourcePath, IPath destinationPath)
    {
        string source = sourcePath.ToStringView();
        string destination = destinationPath.ToStringView();

        if (!System.IO.Path.IsPathRooted(sourcePath.ToStringView()))
            source = System.IO.Path.Combine(new[] { _globalPath.ToStringView(), sourcePath.ToStringView() });

        if (!System.IO.Path.IsPathRooted(destinationPath.ToStringView()))
            destination = System.IO.Path.Combine(new[] { _globalPath.ToStringView(), destinationPath.ToStringView() });

        File.Move(source, destination);
        return new CommandExecutionResult.Success();
    }

    public CommandExecutionResult FileCopy(IPath sourcePath, IPath destinationPath)
    {
        string source = sourcePath.ToStringView();
        string destination = destinationPath.ToStringView();

        if (!System.IO.Path.IsPathRooted(sourcePath.ToStringView()))
            source = System.IO.Path.Combine(new[] { _globalPath.ToStringView(), sourcePath.ToStringView() });

        if (!System.IO.Path.IsPathRooted(destinationPath.ToStringView()))
            destination = System.IO.Path.Combine(new[] { _globalPath.ToStringView(), destinationPath.ToStringView() });

        File.Copy(source, destination);
        return new CommandExecutionResult.Success();
    }

    public CommandExecutionResult FileDelete(IPath path)
    {
        string source = path.ToStringView();

        if (!System.IO.Path.IsPathRooted(path.ToStringView()))
            source = System.IO.Path.Combine(new[] { _globalPath.ToStringView(), path.ToStringView() });

        File.Delete(source);
        return new CommandExecutionResult.Success();
    }

    public CommandExecutionResult FileRename(IPath path, string newName)
    {
        string source = path.ToStringView();

        if (!System.IO.Path.IsPathRooted(path.ToStringView()))
            source = System.IO.Path.Combine(new[] { _globalPath.ToStringView(), path.ToStringView() });

        File.Move(source, newName);
        return new CommandExecutionResult.Success();
    }
}