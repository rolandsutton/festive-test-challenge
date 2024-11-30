namespace BlueCastle.Santa.Lib.Source.Day7;

public interface ILocationProvider
{
    SleighPosition GetPosition(ISleigh sleigh);
}