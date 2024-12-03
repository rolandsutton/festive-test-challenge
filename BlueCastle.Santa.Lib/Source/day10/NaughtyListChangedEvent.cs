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