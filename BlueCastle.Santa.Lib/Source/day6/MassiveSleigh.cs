namespace BlueCastle.Santa.Lib.Source.day6;

public class MassiveSleigh : Sleigh
{
    public MassiveSleigh(IDriverValidator driverValidator, TimeProvider timeProvider, SleighState state) : base(driverValidator, timeProvider, state)
    {
    }

    public MassiveSleigh(IDriverValidator driverValidator, TimeProvider timeProvider) : base(driverValidator, timeProvider)
    {
    }

    protected override bool ValidateDriver(Driver? driver)
    {
        return driver is { License: SleighLicense.Advanced };
    }
}