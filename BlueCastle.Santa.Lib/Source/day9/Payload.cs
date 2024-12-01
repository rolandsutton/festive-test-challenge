namespace BlueCastle.Santa.Lib.Source.day9;

public class Payload
{
    private List<Present> _presents = new();

    public Payload()
    {
    }
    
    public void AddPresent(Present present)
    {
        _presents.Add(present);
    }
    
    public int Weight => _presents.Sum(p => p.Weight);
}