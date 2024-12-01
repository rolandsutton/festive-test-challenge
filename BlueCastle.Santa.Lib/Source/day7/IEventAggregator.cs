namespace BlueCastle.Santa.Lib.Source.day7;

public interface IEventAggregator
{
    T GetEvent<T>() where T:class;
}