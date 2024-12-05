using BlueCastle.Santa.Lib.Source;
using BlueCastle.Santa.Lib.Source.day4;
using Microsoft.Extensions.Time.Testing;
using NSubstitute;
using NUnit.Framework;

namespace BlueCastle.Santa.Lib.Tests.day4;

public class SleighTests
{
    private FakeTimeProvider _timerProvider;
    private IDriverValidator _driverValidator;
    private Func<SleighV2> _sleighFactory;
//No idea how to test sleigh, however sleigh V2 is tested below
    
    [SetUp]
    public void Setup()
    {
        _timerProvider = new FakeTimeProvider();
        _driverValidator = Substitute.For<IDriverValidator>();
        _driverValidator.IsValid("Santa").Returns(true);
        
        _sleighFactory = () => new SleighV2(_driverValidator, _timerProvider);
    }
    
    [Test]
    public void GiveSleigh_WhenAddInvalidDriver_ThenThrowsException()
    {
        // Arrange
        var sleigh = _sleighFactory();
        
        // Act
        var ex = Assert.Throws<ArgumentException>( () => sleigh.AddDriver("Invalid"));
        
        // Assert
        Assert.That(ex, Is.TypeOf<ArgumentException>());
        Assert.That(ex.Message, Is.EqualTo("Invalid driver"));
    }
    
    [Test]
    public void GivenChristmasEve_WhenGo_ThenSleighInTransit()
    {
        // Arrange
        _timerProvider.SetUtcNow(new DateTime(2021, 12, 24));
        var sleigh = _sleighFactory();
        sleigh.AddDriver("Santa");
        
        // Act
        var result = sleigh.Go();
        
        // Assert
        Assert.That(result, Is.True);
        Assert.That(sleigh.State, Is.EqualTo(SleighState.Flying));
    }
    
    [Test]
    public void GivenNotChristmasEve_WhenGo_ThenSleighDoesntWork()
    {
        // Arrange
        _timerProvider.SetUtcNow(new DateTime(2021, 6, 24));
        var sleigh = _sleighFactory();
        sleigh.AddDriver("Santa");
        
        // Act
        var result = sleigh.Go();
        
        // Assert
        Assert.That(result, Is.False);
        Assert.That(sleigh.State, Is.EqualTo(SleighState.Ready));
    }
    
    [Test]
    public void GivenTransitExample_WhenGo_ThenSleighWillWork()
    {
        // Arrange
        _timerProvider.SetUtcNow(new DateTime(2021, 12, 23, 23, 59, 59));
        var sleigh = _sleighFactory();
        sleigh.AddDriver("Santa");
        
        // Act
        var result = sleigh.Go();
        
        // Assert
        Assert.That(result, Is.False);
        Assert.That(sleigh.State, Is.EqualTo(SleighState.Ready));
        
        // Arrange - Advance by 2 seconds.
        _timerProvider.Advance(TimeSpan.FromSeconds(2));
        
        // Act
        result = sleigh.Go();
        
        // Assert
        Assert.That(result, Is.True);
        Assert.That(sleigh.State, Is.EqualTo(SleighState.Flying));
    }
    
}