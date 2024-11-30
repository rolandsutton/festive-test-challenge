using BlueCastle.Santa.Lib.Source.day1;
using NUnit.Framework;

namespace BlueCastle.Santa.Lib.Tests.day1;

public class SleighTests
{
    [Test]
    public void GivenSleigh_WhenGoCalled_ThenInProgressIsTrue()
    {
        // Arrange
        var sleigh = new Sleigh();
        
        // Act
        var result = sleigh.Go();
        
        // Assert
        Assert.That(result, Is.True);
        Assert.That(sleigh.InProgress, Is.True);
    }
    
    [Test]
    public void GivenSleighInProgress_WhenGoCalled_ThenInProgressIsTrue()
    {
        // Arrange
        var sleigh = new Sleigh();
        sleigh.Go();
        
        // Act
        var result = sleigh.Go();
        
        // Assert
        Assert.That(result, Is.True);
        Assert.That(sleigh.InProgress, Is.True);
    }
}