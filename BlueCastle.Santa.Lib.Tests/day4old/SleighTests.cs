using BlueCastle.Santa.Lib.Source.day4;
using NSubstitute;
using NUnit.Framework;

namespace BlueCastle.Santa.Lib.Tests.day4old;

public class SleighTests
{
    private IDriverValidator _driverValidator;
    private Func<Sleigh> _sleighFactory;

    [SetUp]
    public void Setup()
    {
        _driverValidator = Substitute.For<IDriverValidator>();
        
        _sleighFactory = () => new Sleigh(_driverValidator);
    }
    
    [Test]
    public void GivenValidDriver_WhenAddDriver_ThenDriverAdded()
    {
        // Arrange
        var sleigh = _sleighFactory();
        var driver ="Santa";
        _driverValidator.IsValid(driver).Returns(true);
        
        // Act
        sleigh.AddDriver(driver);
        
        // Assert
        _driverValidator.Received(1).IsValid(Arg.Is<string>(s => s == "Santa"));
        Assert.That(sleigh.Driver, Is.EqualTo("Santa"));
    }
    
    [Test]
    public void GivenInvalidDriver_WhenAddDriver_ThenDriverNotAddedAndExceptionThrown()
    {
        // Arrange
        var sleigh = _sleighFactory();
        var driver ="Santa";
        _driverValidator.IsValid(driver).Returns(false);
        
        // Act
        var ex = Assert.Throws<ArgumentException>(() => sleigh.AddDriver(driver));
        
        // Assert
        Assert.That(ex.Message, Is.EqualTo("Invalid driver"));
        _driverValidator.Received(1).IsValid(Arg.Is<string>(s => s == "Santa"));
        Assert.That(sleigh.Driver, Is.Null);
    }
}