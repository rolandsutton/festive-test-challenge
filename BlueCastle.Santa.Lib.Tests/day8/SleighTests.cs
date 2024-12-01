using BlueCastle.Santa.Lib.Source;
using BlueCastle.Santa.Lib.Source.day8;
using NSubstitute;
using NUnit.Framework;
using IDriverValidator = BlueCastle.Santa.Lib.Source.day8.IDriverValidator;
using Sleigh = BlueCastle.Santa.Lib.Source.day8.Sleigh;

namespace BlueCastle.Santa.Lib.Tests.day8;

public class SleighTests
{
    private IDriverValidator _driverValidator;
    private ISackFiller _sackFiller;
    private Func<SleighState, Sleigh> _sleighFactory;
    
    [SetUp]
    public void Setup()
    {
        _driverValidator = Substitute.For<IDriverValidator>();
        _sackFiller = Substitute.For<ISackFiller>();
        _sleighFactory = state => new Sleigh(_driverValidator, _sackFiller, state);
    }
    
    [Test]
    public void GivenSleigh_WhenLoad_ThenPayloadRequested()
    {
        Action<Payload> payloadCallback = null;
        // Arrange
        _sackFiller.When(pp => pp.GetPayload(Arg.Any<ISleigh>(), Arg.Any<Action<Payload>>())).Do(ci => payloadCallback = (Action<Payload>)ci[1]);
        
        var sleigh = _sleighFactory(SleighState.Preparing);
        
        // Act
        sleigh.Load();
        
        Assert.That(payloadCallback, Is.Not.Null);
        payloadCallback(new Payload(12));
        
        // Assert
        _sackFiller.Received(1).GetPayload(sleigh, Arg.Any<Action<Payload>>());
        Assert.That(sleigh.Payload.Weight, Is.EqualTo(12));
        Assert.That(sleigh.State, Is.EqualTo(SleighState.Ready));
    }
}