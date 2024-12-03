namespace BlueCastle.Santa.Lib.Source.day10;

public interface IChangedEvent<T>
{
    void Publish(T changedEvent);
    
    void Subscribe(Action<T> action);
}