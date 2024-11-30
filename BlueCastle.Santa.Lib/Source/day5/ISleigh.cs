namespace BlueCastle.Santa.Lib.Source.day5;

public interface ISleigh
{
    bool Go();
    
    SleighState State { get; }
    
    string Driver { get; }
    
    void AddDriver(string driver);
}