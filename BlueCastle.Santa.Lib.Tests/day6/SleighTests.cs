using BlueCastle.Santa.Lib.Source.day6;
using Microsoft.Extensions.Time.Testing;
using NSubstitute;
using NUnit.Framework;

namespace BlueCastle.Santa.Lib.Tests.day6;

public class SleighTests
{
    private FakeTimeProvider _timerProvider;
    private IDriverValidator _driverValidator;

    [SetUp]
    public void Setup()
    {
        _timerProvider = new FakeTimeProvider();
        _driverValidator = Substitute.For<IDriverValidator>();
        _driverValidator.IsValid(Arg.Any<Func<bool>>()).Returns(f => f.Arg<Func<bool>>().Invoke());
    }
    
    [Test]
    public void GivenMassiveSledge_AddNoviceDriver_ThrowsException()
    {
        // Arrange
        var sleigh = new MassiveSleigh(_driverValidator, _timerProvider);
        var elfDriver = new Driver{Name = "Eric the elf", License = SleighLicense.Novice};
        
        // Act
        var ex = Assert.Throws<ArgumentException>(() => sleigh.AddDriver(elfDriver));
        
        // Assert
        Assert.That(ex.Message, Is.EqualTo("Invalid driver"));
    }
    
    [Test]
    public void GivenMassiveSledge_AddAdvancedDriver_WorksSuccessfully()
    {
        // Arrange
        var sleigh = new MassiveSleigh(_driverValidator, _timerProvider);
        var driver = new Driver{Name = "Santa", License = SleighLicense.Advanced};
        
        // Act
        sleigh.AddDriver(driver);
        
        // Assert
        Assert.That(sleigh.DriverName, Is.EqualTo("Santa"));
    }
    
}