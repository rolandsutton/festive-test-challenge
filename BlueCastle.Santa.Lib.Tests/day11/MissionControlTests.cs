using BlueCastle.Santa.Lib.Source.day11;
using Microsoft.Extensions.Time.Testing;
using NSubstitute;
using NUnit.Framework;

namespace BlueCastle.Santa.Lib.Tests.day11;

public class MissionControlTests
{
    private Func<MissionControl> _missionControlFactory;
    private IEventAggregator _eventAggregator;
    private FakeTimeProvider _timeProvider;

    [SetUp]
    public void Setup()
    {
        _eventAggregator = Substitute.For<IEventAggregator>();
        _timeProvider = new FakeTimeProvider();
        _missionControlFactory = () => new MissionControl(_eventAggregator, _timeProvider);
    }
    
    [Test]
    public void GivenMissionControlInTheSmmer_WhenGo_ThenNothing()
    {
        // Arrange
        _timeProvider.SetUtcNow(new DateTimeOffset(2024, 6, 1, 0, 0, 0, TimeSpan.Zero));
        var missionControl = _missionControlFactory();
        
        // Act
        missionControl.Go();
        
        // Assert
        _eventAggregator.DidNotReceive().GetEvent<MissionStartedEvent>();
    }
}