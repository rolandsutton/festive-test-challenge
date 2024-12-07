namespace BlueCastle.Santa.Lib.Source.day6;

public class  MiniSleigh : Sleigh
{
    public MiniSleigh(IDriverValidator driverValidator, TimeProvider timeProvider, SleighState state) : base(driverValidator, timeProvider, state)
    {
    }

    public MiniSleigh(IDriverValidator driverValidator, TimeProvider timeProvider) : base(driverValidator, timeProvider)
    {
    }
}