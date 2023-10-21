namespace Itmo.ObjectOrientedProgramming.Lab2.Bios;

public interface IBiosBuilder
{
    IBiosBuilder WithBiosType(BiosType biosType);

    IBiosBuilder WithSupportedProcessor(string supportedProcessor);

    IBios Build();
}