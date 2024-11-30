using BlueCastle.Santa.Lib.Source.day3;

namespace BlueCastle.Santa.Lib.Source.day2;

public class Sleigh: ISleigh
{
    private SleighState _state = SleighState.Ready;

    public bool Go()
    {
        if(State == SleighState.Ready)
        {
            _state = SleighState.Flying;
            return true;
        }
        
        return false;
    }

    public SleighState State => _state;
}