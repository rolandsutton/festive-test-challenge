namespace BlueCastle.Santa.Lib.Source.day8;

public interface ISleigh
{
    void Load();
    
    bool Go();
    
    SleighState State { get; }
    
    string Driver { get; }
    
    Payload Payload { get; }
    
    void AddDriver(string driver);
}