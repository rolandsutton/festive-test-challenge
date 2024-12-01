namespace BlueCastle.Santa.Lib.Source.day9;

public interface ISackFiller
{
    bool GetPayload(ISleigh target, Action<Payload> callback);
}

public interface IPresentProvider
{
    Present GetNextPresent();
}

public class Present
{
    public int Weight { get; set; }
}

public class SackFiller : ISackFiller
{
    private const int MaxSkips = 10;
    private readonly IPresentProvider _presentProvider;

    public SackFiller(IPresentProvider presentProvider)
    {
        _presentProvider = presentProvider;
    }
    
    public bool GetPayload(ISleigh target, Action<Payload> callback)
    {
        int skippedPresents = 0;
        Payload payload = new();
        do
        {
            var present = _presentProvider.GetNextPresent();
            if (present != null && payload.Weight + present.Weight <= target.Capacity)
            {
                payload.AddPresent(present);
                skippedPresents = 0;
            }else
            {
                skippedPresents++;
            }
        } while (payload.Weight < target.Capacity && skippedPresents < MaxSkips);
        callback(payload);
        return skippedPresents < MaxSkips;
    }

}