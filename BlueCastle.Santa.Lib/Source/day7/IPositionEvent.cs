namespace BlueCastle.Santa.Lib.Source.day7;

public interface IPositionEvent
{
    SleighPosition Position { get; }

    void Publish(PositionEvent positionEvent);
}