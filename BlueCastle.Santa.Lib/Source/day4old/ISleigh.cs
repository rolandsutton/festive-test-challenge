namespace BlueCastle.Santa.Lib.Source.day4old;

public interface ISleigh
{
    bool Go();
    
    SleighState State { get; }
    
    string Driver { get; }
    
    void AddDriver(string driver);
}