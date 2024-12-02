namespace BlueCastle.Santa.Lib.Source.day10;

public class NaughtyListChangedEvent :IChangedEvent<NaughtyListChangedEvent>
{
    public void Publish(NaughtyListChangedEvent changedEvent)
    {
    }

    public void Subscribe(Action<NaughtyListChangedEvent> action)
    {
    }
}

public interface IChangedEvent<T>
{
    void Publish(T changedEvent);
    
    void Subscribe(Action<T> action);
}