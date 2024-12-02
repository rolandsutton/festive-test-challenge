using BlueCastle.Santa.Lib.Source.day7;

namespace BlueCastle.Santa.Lib.Source.day10;

public class Sleigh: ISleigh
{
    private readonly IEventAggregator _eventAggregator;
    private SleighState _state;
    private string _driver = null;

    public Sleigh(
        IEventAggregator eventAggregator,
        SleighState state)
    {
        _state = state; 
        eventAggregator.GetEvent<IChangedEvent<NaughtyListChangedEvent>>().Subscribe(OnNaughtyListChanged);
    }

    private void OnNaughtyListChanged(NaughtyListChangedEvent naughtyListChangedEvent)
    {
        _state = SleighState.Preparing;
    }

    public Sleigh(IEventAggregator eventAggregator): this( eventAggregator, SleighState.Ready)
    {
    }
    
    public bool Go()
    {
        if(State == SleighState.Ready ) 
        {
            _state = SleighState.Flying;
            return true;
        }
        
        return false;
    }

    public SleighState State => _state;
}