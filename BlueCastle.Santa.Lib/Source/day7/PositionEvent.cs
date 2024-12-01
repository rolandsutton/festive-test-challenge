namespace BlueCastle.Santa.Lib.Source.day7;

public class PositionEvent : IPositionEvent
{
    public SleighPosition Position { get; }

    public PositionEvent(SleighPosition sleighPosition)
    {
        Position = sleighPosition;
    }

    public void Publish(PositionEvent positionEvent)
    {
    }
}