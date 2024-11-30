namespace BlueCastle.Santa.Lib.Source.Day7;

public interface IPositionEvent
{
    SleighPosition Position { get; }

    void Publish(PositionEvent positionEvent);
}