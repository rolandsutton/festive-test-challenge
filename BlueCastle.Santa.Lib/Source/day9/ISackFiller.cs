namespace BlueCastle.Santa.Lib.Source.day9;

public interface ISackFiller
{
    bool GetPayload(ISleigh target, Action<Payload> callback);
}