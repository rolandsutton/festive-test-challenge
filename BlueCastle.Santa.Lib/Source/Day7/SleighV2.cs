namespace BlueCastle.Santa.Lib.Source.Day7;

public class Sleighv2: ISleigh
{
    private readonly IDriverValidator _driverValidator;
    private readonly TimeProvider _timeProvider;
    private readonly IEventAggregator _eventAggregator;
    private readonly ILocationProvider _locationProvider;
    private SleighState _state;
    private string _driver = null;

    public Sleighv2(IDriverValidator driverValidator,
        TimeProvider timeProvider,
        IEventAggregator eventAggregator,
        ILocationProvider locationProvider,
        SleighState state)
    {
        _driverValidator = driverValidator;
        _timeProvider = timeProvider;
        _eventAggregator = eventAggregator;
        _locationProvider = locationProvider;
        _state = state;
        _ = _timeProvider.CreateTimer(NotifyPosition, null, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10));
    }

    public Sleighv2(IDriverValidator driverValidator, TimeProvider timeProvider, IEventAggregator eventAggregator, ILocationProvider locationProvider): this(driverValidator, timeProvider, eventAggregator, locationProvider, SleighState.Ready)
    {
    }
    
    public bool Go()
    {
        if(State == SleighState.Ready 
           && !string.IsNullOrWhiteSpace(Driver)
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
    
    private void NotifyPosition(object? state)
    {
        var position = _locationProvider.GetPosition(this);
        _eventAggregator.GetEvent<IPositionEvent>().Publish(new PositionEvent(position));
    }
}
