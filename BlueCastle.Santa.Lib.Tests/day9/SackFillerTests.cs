using BlueCastle.Santa.Lib.Source.day9;
using NSubstitute;
using NUnit.Framework;

namespace BlueCastle.Santa.Lib.Tests.day9;

public class SackFillerTests
{
    private IPresentProvider _presentProvider;
    private ISleigh _sleigh;

    [SetUp]
    public void Setup()
    {
        _presentProvider = Substitute.For<IPresentProvider>();
        _sleigh = Substitute.For<ISleigh>();
    }
    
    [Test]
    public void GivenSimpleCase_WhenGetPayload_ThenReturnsPayload()
    {
        // Arrange
        _presentProvider.GetNextPresent().Returns(new Present{Weight = 2});
        _sleigh.Capacity.Returns(12);
        var sackFiller = new SackFiller(_presentProvider);
        
        Payload result = null;
        // Act
        var filled = sackFiller.GetPayload(_sleigh, payload => { result = payload; });
        
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Weight, Is.EqualTo(12));
        Assert.That(filled, Is.True);
        _presentProvider.Received(6).GetNextPresent();
    }
    
    [Test]
    public void GivenLargePresents_WhenGetPayload_ThenLoopExited()
    {
        // Arrange
        _presentProvider.GetNextPresent().Returns(new Present{Weight = 50});
        _sleigh.Capacity.Returns(12);
        var sackFiller = new SackFiller(_presentProvider);
        Payload result = null;
        
        // Act
        var filled = sackFiller.GetPayload(_sleigh, payload => { result = payload; });
        
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Weight, Is.EqualTo(0));
        Assert.That(filled, Is.False);
        _presentProvider.Received(10).GetNextPresent();
    }
    
    [Test]
    public void GivenNoPresents_WhenGetPayload_ThenReturnsEmptyPayload()
    {
        // Arrange
        _presentProvider.GetNextPresent().Returns(null as Present);
        _sleigh.Capacity.Returns(12);
        var sackFiller = new SackFiller(_presentProvider);
        Payload result = null;
        
        // Act
        var filled = sackFiller.GetPayload(_sleigh, payload => { result = payload; });
        
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Weight, Is.EqualTo(0));
        Assert.That(filled, Is.False);
        _presentProvider.Received(10).GetNextPresent();
    }
    
    [Test]
    public void GivenComplexPresents_WhenGetPayload_ThenReturnsPayload()
    {
        // Arrange
        _presentProvider.GetNextPresent().Returns(new Present(){Weight = 1},new Present(){Weight = 5},new Present(){Weight = 2},new Present(){Weight = 4},new Present(){Weight = 1});
        _sleigh.Capacity.Returns(2);
        Payload result = null;
        var sackFiller = new SackFiller(_presentProvider);
        // Act
        var filled = sackFiller.GetPayload(_sleigh, payload => { result = payload; });
        
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Weight, Is.EqualTo(2));
        Assert.That(filled, Is.True);
        _presentProvider.Received(5).GetNextPresent();
    }
    
    [Test]
    public void GivenNonMatchingPresents_WhenGetPayload_ThenReturnsPartialPayload()
    {
        // Arrange
        _presentProvider.GetNextPresent().Returns(new Present { Weight = 5});
        _sleigh.Capacity.Returns(6);
        var sackFiller = new SackFiller(_presentProvider);
        Payload result = null;
        
        // Act
        var filled = sackFiller.GetPayload(_sleigh, payload => { result = payload; });
        
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Weight, Is.EqualTo(5));
        Assert.That(filled, Is.False);
        _presentProvider.Received(11).GetNextPresent();
    }
}