namespace BlueCastle.Santa.Lib.Source.day8;

public class Payload
{
    private readonly int _weight;

    public Payload(int weight)
    {
        _weight = weight;
    }
    
    public int Weight => _weight;
}