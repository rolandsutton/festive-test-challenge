using BlueCastle.Santa.Lib.Source.day5;
using Microsoft.Extensions.Time.Testing;
using NSubstitute;
using NUnit.Framework;

namespace BlueCastle.Santa.Lib.Tests.day5;

public class SleighTests
{
    private IDriverValidator _driverValidator;
    private FakeTimeProvider _timeProvider;
    private Func<Sleigh> _sleighFactory;

    [SetUp]
    public void Setup()
    {
        _driverValidator = Substitute.For<IDriverValidator>();
        _timeProvider = new FakeTimeProvider();
        _sleighFactory = () => new Sleigh(_driverValidator, _timeProvider);
    }

    [Test]
    public void GivenSleigh_WhenAddDriverWithBrokenValidator_ThenExpectException()
    {
        // Arrange
        _driverValidator.TryIsValid(Arg.Any<string>(), out Arg.Any<IDriverInfo>()).Returns(false);
        var target = _sleighFactory();
        
        // Act
        var ex = Assert.Throws<ArgumentException>(() => target.AddDriver("Santa"));
        
        // Assert
        Assert.That(ex.Message, Is.EqualTo("Unable to validate driver"));
        _driverValidator.Received(1).TryIsValid("Santa", out Arg.Any<IDriverInfo>());
        Assert.IsNull(target.Driver);
    }
    
    [Test]
    public void GivenSleigh_WhenAddInvalidDriver_ThenExpectException()
    {
        // Arrange
        var driverInfo = Substitute.For<IDriverInfo>();
        driverInfo.IsDriver.Returns(false);
        _driverValidator.TryIsValid(Arg.Any<string>(), out Arg.Any<IDriverInfo>()).Returns(true).AndDoes(x => x[1] = driverInfo);
        var target = _sleighFactory();
        
        // Act
        var ex = Assert.Throws<ArgumentException>(() => target.AddDriver("Santa"));
        
        // Assert
        Assert.That(ex.Message, Is.EqualTo("Invalid driver"));
        _driverValidator.Received(1).TryIsValid("Santa", out Arg.Any<IDriverInfo>());
        _ = driverInfo.Received(1).IsDriver;
        Assert.IsNull(target.Driver);
    }
    
    [Test]
    public void GivenSleigh_WhenAddValidDriver_ThenDriverAdded()
    {
        // Arrange
        var driverInfo = Substitute.For<IDriverInfo>();
        driverInfo.IsDriver.Returns(true);
        _driverValidator.TryIsValid(Arg.Any<string>(), out Arg.Any<IDriverInfo>()).Returns(true).AndDoes(x => x[1] = driverInfo);
        var target = _sleighFactory();
        
        // Act
        target.AddDriver("Santa");
        
        // Assert
        _driverValidator.Received(1).TryIsValid("Santa", out Arg.Any<IDriverInfo>());
        _ = driverInfo.Received(1).IsDriver;
        Assert.That(target.Driver, Is.EqualTo("Santa"));
    }
}