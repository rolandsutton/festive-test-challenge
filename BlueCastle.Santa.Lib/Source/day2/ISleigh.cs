namespace BlueCastle.Santa.Lib.Source.day2;

public interface ISleigh
{
    bool Go();
    
    SleighState State { get; }
}