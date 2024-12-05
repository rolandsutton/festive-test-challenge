
namespace BlueCastle.Santa.Lib.Source.day3;

public class Sleigh: ISleigh
{
    private SleighState _state;
    private string _driver = null;

    public Sleigh(SleighState state)
    {
        _state = state;
    }
    
    public Sleigh() :this(SleighState.Ready)
    {
    }
    
    public bool Go()
    {
        if(State == SleighState.Ready && IsValidDriver(Driver))
        {
            _state = SleighState.Flying;
            return true;
        }
        
        return false;
    }
    public void AddDriver(string driver)
    {
        if(IsValidDriver(driver))
        {
            _driver = driver;
        }
    }

    public SleighState State => _state;

    public string Driver => _driver;

    private bool IsValidDriver(string target)
    {
        return !string.IsNullOrWhiteSpace(target);
    }
}
