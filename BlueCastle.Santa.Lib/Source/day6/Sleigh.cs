namespace BlueCastle.Santa.Lib.Source.day6;

public abstract class Sleigh: ISleigh
{
    private readonly IDriverValidator _driverValidator;
    private readonly TimeProvider _timeProvider;
    private SleighState _state;
    private Driver? _driver = null;

    protected Sleigh(IDriverValidator driverValidator,
        TimeProvider timeProvider,
        SleighState state)
    {
        _driverValidator = driverValidator;
        _timeProvider = timeProvider;
        _state = state;
    }

    protected Sleigh(IDriverValidator driverValidator, TimeProvider timeProvider) :this(driverValidator, timeProvider, SleighState.Ready)
    {
    }
    
    public bool Go()
    {
        if(State == SleighState.Ready 
           && ValidateDriver(_driver)
           && _timeProvider.GetLocalNow().Day == 24 && _timeProvider.GetLocalNow().Month == 12) 
        {
            _state = SleighState.Flying;
            return true;
        }
        
        return false;
    }

    protected virtual bool ValidateDriver(Driver? driver)
    {
        return driver != null;
    }

    public SleighState State => _state;

    public string DriverName
    {
        get
        {
            if (_driver != null) return _driver.Name;
            return string.Empty;
        }
    }

    public void AddDriver(Driver driver)
    {
        if(!_driverValidator.IsValid(() => ValidateDriver(driver)))
        {
            throw new ArgumentException("Invalid driver");
        }
        _driver = driver; 
    }
}