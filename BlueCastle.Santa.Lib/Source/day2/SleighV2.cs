using BlueCastle.Santa.Lib.Source.day3;

namespace BlueCastle.Santa.Lib.Source.day2;

public class SleighV2: ISleigh
{
    private SleighState _state;

    public SleighV2(SleighState state)
    {
        _state = state;
    }
    
    public SleighV2() :this(SleighState.Ready)
    {
    }
    
    public bool Go()
    {
        if(State == SleighState.Ready)
        {
            _state = SleighState.InTransit;
            return true;
        }
        
        return false;
    }

    public SleighState State => _state;
}