namespace BlueCastle.Santa.Lib.Source.day11;

public interface IEventAggregator
{
    T GetEvent<T>() where T:class;
}