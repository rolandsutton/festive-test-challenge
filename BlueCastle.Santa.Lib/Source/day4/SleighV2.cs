namespace BlueCastle.Santa.Lib.Source.day4;

public class SleighV2: ISleigh
{
    private readonly IDriverValidator _driverValidator;
    private readonly TimeProvider _timeProvider;
    private SleighState _state;
    private string _driver = null;

    public SleighV2(IDriverValidator driverValidator,
        TimeProvider timeProvider,
        SleighState state)
    {
        _driverValidator = driverValidator;
        _timeProvider = timeProvider;
        _state = state;
    }
    
    public SleighV2(IDriverValidator driverValidator, TimeProvider timeProvider) :this(driverValidator, timeProvider, SleighState.Ready)
    {
    }
    
    public bool Go()
    {
        if(State == SleighState.Ready 
           && !_driverValidator.IsValid(Driver)
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
        if(!_driverValidator.IsValid(driver))
        {
            throw new ArgumentException("Invalid driver");
        }
        _driver = driver; 
    }
}