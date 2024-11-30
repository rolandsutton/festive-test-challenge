namespace BlueCastle.Santa.Lib.Source.day6;

public interface ISleigh
{
    bool Go();
    
    SleighState State { get; }
    
    string DriverName { get; }
    
    void AddDriver(Driver driver);
}