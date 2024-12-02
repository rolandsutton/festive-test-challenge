using BlueCastle.Santa.Lib.Source;
using BlueCastle.Santa.Lib.Source.day10;
using NSubstitute;
using NUnit.Framework;

namespace BlueCastle.Santa.Lib.Tests.day10;

public class SleighTests
{
    private IEventAggregator _eventAggregator;
    private Func<Sleigh> _sleighFactory;
    private IChangedEvent<NaughtyListChangedEvent> _naughtyListChangedEvent;

    [SetUp]
    public void Setup()
    {
        _eventAggregator = Substitute.For<IEventAggregator>();
        _naughtyListChangedEvent = Substitute.For<IChangedEvent<NaughtyListChangedEvent>>();
        _eventAggregator.GetEvent<IChangedEvent<NaughtyListChangedEvent>>().Returns(_naughtyListChangedEvent);
        _sleighFactory = () => new Sleigh(_eventAggregator);
    }
    
    [Test]
    public void GivenSleigh_WhenNaughtyListChangedEventPublished_ThenSleighPositionUpdateStatePreparing()
    {
        // Arrange
        Action<NaughtyListChangedEvent> naughtyListChangedAction = null;
        _naughtyListChangedEvent
            .WhenForAnyArgs(e => e.Subscribe(Arg.Any<Action<NaughtyListChangedEvent>>()))
            .Do((ci) =>
            {
                naughtyListChangedAction = (Action<NaughtyListChangedEvent>)ci[0];
            });
        
        var sleigh = _sleighFactory();
        // Act
        _eventAggregator.Received(1).GetEvent<IChangedEvent<NaughtyListChangedEvent>>();
        Assert.That(naughtyListChangedAction, Is.Not.Null);
        naughtyListChangedAction(new NaughtyListChangedEvent());
        
        // Assert
        Assert.That(sleigh.State, Is.EqualTo(SleighState.Preparing));
    }
}