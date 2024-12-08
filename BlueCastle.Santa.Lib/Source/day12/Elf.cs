namespace BlueCastle.Santa.Lib.Source.day12;

public class Elf : IElf
{
    private List<IShelf> visitedShelves = new();
    
    public Elf(string name)
    {
        Name = name;
    }

    public string Name { get; }
    
    public IEnumerable<IShelf> VisitedShelves => visitedShelves;

    public bool TryAddToShelf(IShelf shelf)
    {
        return shelf.TryAdd(this, (s) => visitedShelves.Add(s));
    }
}