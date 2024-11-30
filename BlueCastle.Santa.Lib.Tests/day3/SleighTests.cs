using BlueCastle.Santa.Lib.Source;
using BlueCastle.Santa.Lib.Source.day3;
using NUnit.Framework;

namespace BlueCastle.Santa.Lib.Tests.day3;

public class SleighTests
{
    [Test]
    public void GivenValidDriverName_WhenAddDriver_ThenDriverNameSet()
    {
        // Arrange
        var sleigh = new Sleigh();
        
        // Act
        sleigh.AddDriver("Santa");
        
        // Assert
        Assert.That(sleigh.Driver, Is.EqualTo("Santa"));
    }
    
    [TestCase("")]
    [TestCase(null)]
    [TestCase("     ")]
    public void GivenInvalidDriverName_WhenAddDriver_ThenDriverNameNotSet(string driver)
    {
        // Arrange
        var sleigh = new Sleigh();
        
        // Act
        sleigh.AddDriver(driver);
        
        // Assert
        Assert.That(sleigh.Driver, Is.Null);
    }
    
    
    [Test]
    public void GivenSleighWithNoDriver_WhenGoCalled_ThenStateNotChanged()
    {
        // Arrange
        var sleigh = new Sleigh();
        
        // Act
        var result = sleigh.Go();
        
        // Assert
        Assert.That(result, Is.False);
        Assert.That(sleigh.State, Is.EqualTo(SleighState.Ready));
    }
    
    [Test]
    public void GivenSleighWithDriver_WhenGoCalled_ThenStateIsInProgress()
    {
        // Arrange
        var sleigh = new Sleigh();
        sleigh.AddDriver("Santa");
        
        // Act
        var result = sleigh.Go();
        
        // Assert
        Assert.That(result, Is.True);
        Assert.That(sleigh.State, Is.EqualTo(SleighState.InTransit));
    }
}