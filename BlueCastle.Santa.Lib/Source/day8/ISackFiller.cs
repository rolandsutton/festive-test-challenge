namespace BlueCastle.Santa.Lib.Source.day8;

public interface ISackFiller
{
    void GetPayload(ISleigh target, Action<Payload> callback);
}
