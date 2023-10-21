namespace Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;

public abstract record PciController
{
    private PciController() { }

    public sealed record PciExpressV1 : PciController;

    public sealed record PciExpressV2 : PciController;

    public sealed record PciExpressV3 : PciController;

    public sealed record PciExpressV4 : PciController;

    public sealed record PciExpressV5 : PciController;
}