namespace BlueCastle.Santa.Lib.Source.day1;

public class Sleigh: ISleigh
{
    private bool _inProgress;

    public bool Go()
    {
        if(!InProgress)
        {
            _inProgress = true;
        }
        
        return InProgress;
    }

    public bool InProgress => _inProgress;
}