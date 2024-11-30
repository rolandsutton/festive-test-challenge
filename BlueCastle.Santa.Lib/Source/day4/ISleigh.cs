namespace BlueCastle.Santa.Lib.Source.day4;

public interface ISleigh
{
    bool Go();
    
    SleighState State { get; }
    
    string Driver { get; }
    
    void AddDriver(string driver);
}