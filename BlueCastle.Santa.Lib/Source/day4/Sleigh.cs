
namespace BlueCastle.Santa.Lib.Source.day4;

public class Sleigh: ISleigh
{
    private readonly IDriverValidator _driverValidator;
    private SleighState _state;
    private string _driver = null;

    public Sleigh(IDriverValidator driverValidator, SleighState state)
    {
        _driverValidator = driverValidator;
        _state = state;
    }
    
    public Sleigh(IDriverValidator driverValidator) :this(driverValidator, SleighState.Ready)
    {
    }
    
    public bool Go()
    {
        if(State == SleighState.Ready 
           && !_driverValidator.IsValid(Driver)
           && DateTime.Now.Day == 24 && DateTime.Now.Month == 12) 
        {
            _state = SleighState.Flying;
            return true;
        }
        
        return false;
    }

    public SleighState State => _state;

    public string Driver => _driver;
    
    public void AddDriver(string driver)
    {
        if(!_driverValidator.IsValid(driver))
        {
            throw new ArgumentException("Invalid driver");
        }
        _driver = driver; 
    }
}