
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
        if(State == SleighState.Ready && !string.IsNullOrWhiteSpace(Driver))
        {
            _state = SleighState.InTransit;
            return true;
        }
        
        return false;
    }

    public SleighState State => _state;

    public string Driver => _driver;
    
    public void AddDriver(string driver)
    {
        if(!string.IsNullOrWhiteSpace(driver))
        {
            _driver = driver;
        }
    }
}