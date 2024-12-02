namespace BlueCastle.Santa.Lib.Source.day10;

public interface IEventAggregator
{
    T GetEvent<T>() where T:class;
}