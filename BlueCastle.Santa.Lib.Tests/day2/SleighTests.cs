using BlueCastle.Santa.Lib.Source;
using BlueCastle.Santa.Lib.Source.day2;
using NUnit.Framework;

namespace BlueCastle.Santa.Lib.Tests.day2;

[TestFixture]
public class SleighTests
{
    [Test]
    public void GivenSleighReady_WhenGoCalled_ThenStateInTransit()
    {
        // Arrange
        var sleigh = new SleighV2();
        
        // Act
        var result = sleigh.Go();
        
        // Assert
        Assert.That(result, Is.True);
        Assert.That(sleigh.State, Is.EqualTo(SleighState.InTransit));
    }
    
    [TestCase(SleighState.OnStandby)]
    [TestCase(SleighState.InTransit)]
    public void GivenSleighNotReady_WhenGoCalled_ThenStateNotInTransit(SleighState state)
    {
        // Arrange
        var sleigh = new SleighV2(state);
        
        // Act
        var result = sleigh.Go();
        
        // Assert
        Assert.That(result, Is.False);
        Assert.That(sleigh.State, Is.EqualTo(state));
    }
    
}