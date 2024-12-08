namespace BlueCastle.Santa.Lib.Source.day12;

public interface IShelf
{
    bool TryAdd(IElf elf, Action<IShelf> completeAssignment);
}