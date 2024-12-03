namespace BlueCastle.Santa.Lib.Source.day11;

public interface IMissionControl
{
    void Go();
}

public class MissionControl :IMissionControl
{
    private readonly IEventAggregator _eventAggregator;
    private readonly TimeProvider _timeProvider;

    public MissionControl(IEventAggregator eventAggregator, TimeProvider timeProvider)
    {
        _eventAggregator = eventAggregator;
        _timeProvider = timeProvider;
    }

    public void Go()
    {
        var now = _timeProvider.GetLocalNow();
        if(now is { Day: 24, Month: 12 })
        {
            _eventAggregator.GetEvent<MissionStartedEvent>().Publish("Go");
            var timeUntilReturn = new DateTimeOffset(now.Year, now.Month, now.Day, 23,45,0, TimeSpan.Zero) - _timeProvider.GetLocalNow();
            _ = _timeProvider.CreateTimer(TriggerRecall, null, timeUntilReturn, Timeout.InfiniteTimeSpan);                
        }
    }

    private void TriggerRecall(object? state)
    {
        _eventAggregator.GetEvent<MissionReturnEvent>().Publish("Comeback");
    }
}

internal class MissionReturnEvent : IChangedEvent<string>
{
    public void Publish(string changedEvent)
    {
        throw new NotImplementedException();
    }

    public void Subscribe(Action<string> action)
    {
        throw new NotImplementedException();
    }
}

public class MissionStartedEvent : IChangedEvent<string>
{
    public void Publish(string changedEvent)
    {
        throw new NotImplementedException();
    }

    public void Subscribe(Action<string> action)
    {
        throw new NotImplementedException();
    }
}