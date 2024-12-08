namespace BlueCastle.Santa.Lib.Source.day12;

public interface IElf
{
    string Name { get; }
    
    IEnumerable<IShelf> VisitedShelves { get; }
    
    bool TryAddToShelf(IShelf shelf);
}