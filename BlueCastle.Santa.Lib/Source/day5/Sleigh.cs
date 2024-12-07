namespace BlueCastle.Santa.Lib.Source.day5;

public class Sleigh: ISleigh
{
    private readonly IDriverValidator _driverValidator;
    private readonly TimeProvider _timeProvider;
    private SleighState _state;
    private string _driver = null;

    public Sleigh(IDriverValidator driverValidator,
        TimeProvider timeProvider,
        SleighState state)
    {
        _driverValidator = driverValidator;
        _timeProvider = timeProvider;
        _state = state;
    }
    
    public Sleigh(IDriverValidator driverValidator, TimeProvider timeProvider) :this(driverValidator, timeProvider, SleighState.Ready)
    {
    }
    
    public bool Go()
    {
        var validated = _driverValidator.TryIsValid(Driver, out var driverInfo); 
        if(!validated)
        {
            return false;
        }
        if(State == SleighState.Ready 
           && driverInfo.IsDriver
           && _timeProvider.GetLocalNow().Day == 24 && _timeProvider.GetLocalNow().Month == 12) 
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
        var validated = _driverValidator.TryIsValid(driver, out var driverInfo); 
        if(!validated)
        {
            throw new ArgumentException("Unable to validate driver");
        }
        
        if(!driverInfo.IsDriver)
        {
            throw new ArgumentException("Invalid driver");
        }
        _driver = driver; 
    }
}
