using BlueCastle.Santa.Lib.Source.Day7;
using Microsoft.Extensions.Time.Testing;
using NSubstitute;
using NUnit.Framework;

namespace BlueCastle.Santa.Lib.Tests.day7;

public class SleighV2Tests
{
    private IDriverValidator _driverValidator;
    private FakeTimeProvider _timeProvider;
    private ILocationProvider _locationProvider;
    private IEventAggregator _eventAggregator;
    private Func<ISleigh> _sleighFactory;
    private IPositionEvent _positionEvent;

    [SetUp]
    public void Setup()
    {
        _driverValidator = Substitute.For<IDriverValidator>();
        _timeProvider = new FakeTimeProvider();
        _locationProvider = Substitute.For<ILocationProvider>();
        _positionEvent = Substitute.For<IPositionEvent>();
        _eventAggregator = Substitute.For<IEventAggregator>();
        _eventAggregator.GetEvent<IPositionEvent>().Returns(_positionEvent);
        _sleighFactory = () => new Sleighv2(_driverValidator, _timeProvider, _eventAggregator, _locationProvider);
    }

    [Test]
    public void GivenSleigh_ThenPositionBroadcast()
    {
        // Arrange
        _locationProvider.GetPosition(Arg.Any<ISleigh>()).Returns(new SleighPosition { Latitude = 1, Longitude = 2 });
        var sleigh = _sleighFactory();
        
        _timeProvider.Advance(TimeSpan.FromSeconds(11));
        
        // Assert
        _locationProvider.Received(1).GetPosition(sleigh);
        _eventAggregator.GetEvent<IPositionEvent>().Received(1);
        _positionEvent.Received(1).Publish(Arg.Is<PositionEvent>(pe => pe.Position.Latitude == 1 && pe.Position.Longitude == 2));
        
    }
}