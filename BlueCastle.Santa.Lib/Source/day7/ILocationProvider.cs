namespace BlueCastle.Santa.Lib.Source.day7;

public interface ILocationProvider
{
    SleighPosition GetPosition(ISleigh sleigh);
}