namespace BlueCastle.Santa.Lib.Source.day10;

public interface ISleigh
{
    bool Go();
    
    SleighState State { get; }
}