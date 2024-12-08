using BlueCastle.Santa.Lib.Source.day12;
using NSubstitute;
using NUnit.Framework;

namespace BlueCastle.Santa.Lib.Tests.day12;

public class ElfTests
{
    [SetUp]
    public void Setup()
    {
        
    }
    
    [Test]
    public void GivenElf_WhenTryAddToShelfFail_ThenShelfIsNotVisited()
    {
        // Arrange
        var elf = new Elf("Buddy");
        var shelf = Substitute.For<IShelf>();
        shelf.TryAdd(elf, Arg.Any<Action<IShelf>>()).Returns(false);
        
        // Act
        var result = elf.TryAddToShelf(shelf);
        
        // Assert
        Assert.That(result, Is.False);
        shelf.Received().TryAdd(elf, Arg.Any<Action<IShelf>>());
        Assert.That(elf.VisitedShelves, Has.No.Member(shelf));
        Assert.That(elf.VisitedShelves, Is.Empty);
    }
    
    [Test]
    public void GivenElf_WhenTryAddToShelf_ThenShelfIsVisited()
    {
        // Arrange
        var elf = new Elf("Buddy");
        var shelf = Substitute.For<IShelf>();
        shelf.TryAdd(elf, Arg.Any<Action<IShelf>>()).Returns(true).AndDoes(ci => ci.Arg<Action<IShelf>>()(shelf));
        // Act
        var result = elf.TryAddToShelf(shelf);
        
        // Assert
        Assert.That(result, Is.True);
        shelf.Received().TryAdd(elf, Arg.Any<Action<IShelf>>());
        Assert.That(elf.VisitedShelves, Has.Member(shelf));
        Assert.That(elf.VisitedShelves, Has.Exactly(1).Items);
    }
}