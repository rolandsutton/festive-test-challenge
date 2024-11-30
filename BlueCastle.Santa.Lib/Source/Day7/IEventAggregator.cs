namespace BlueCastle.Santa.Lib.Source.Day7;

public interface IEventAggregator
{
    T GetEvent<T>() where T:class;
}