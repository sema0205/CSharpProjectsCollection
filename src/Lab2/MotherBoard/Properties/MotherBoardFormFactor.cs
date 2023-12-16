namespace Itmo.ObjectOrientedProgramming.Lab2.MotherBoard;

public abstract record MotherBoardFormFactor
{
    private MotherBoardFormFactor() { }

    public sealed record Atx : MotherBoardFormFactor;

    public sealed record MicroAtx : MotherBoardFormFactor;

    public sealed record EAtx : MotherBoardFormFactor;

    public sealed record MiniAtx : MotherBoardFormFactor;

    public sealed record MiniItx : MotherBoardFormFactor;

    public sealed record MiniStx : MotherBoardFormFactor;
}