namespace BlueCastle.Santa.Lib.Source.day8;

public class Sleigh: ISleigh
{
    private readonly IDriverValidator _driverValidator;
    private readonly ISackFiller _sackFiller;
    private SleighState _state;
    private string _driver = null;
    private Payload _payload;

    public Payload Payload
    {
        get => _payload;
    }

    public Sleigh(IDriverValidator driverValidator, ISackFiller sackFiller, SleighState state)
    {
        _driverValidator = driverValidator;
        _sackFiller = sackFiller;
        _state = state;
    }
    
    public Sleigh(IDriverValidator driverValidator, ISackFiller sackFiller) :this(driverValidator, sackFiller, SleighState.Ready)
    {
    }

    public void Load()
    {
        if(State == SleighState.Preparing)
        {
            _sackFiller.GetPayload(this, HandlePayload);
        }
    }

    private void HandlePayload(Payload payload)
    {
        _state = SleighState.Ready;
        _payload = payload;
    }

    public bool Go()
    {
        if(State == SleighState.Ready && !string.IsNullOrWhiteSpace(Driver))
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
