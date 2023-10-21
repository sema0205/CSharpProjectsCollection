namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerConfigurator;

public interface IComputerConfiguratorBuilderDirector
{
    IComputerConfiguratorBuilder Direct(IComputerConfiguratorBuilder builder);
}