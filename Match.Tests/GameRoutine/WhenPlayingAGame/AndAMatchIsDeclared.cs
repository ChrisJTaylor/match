using System.Linq;

namespace Match.Tests.GameRoutine.WhenPlayingAGame;

using TestHelpers;

public class AndAMatchIsDeclared
{
    private IGameState _gameState = null!;
    
    [OneTimeSetUp]
    public void WhenAGameHasAMatchingPair()
    {
        var selectedOptions = new GameOptions(1, Suit);
        
        var cardCollection = new[]
        {
            new Card(Ace, Diamonds),
            new Card(Three, Clubs),
            new Card(Two, Diamonds),
            new Card(Three, Diamonds),
            new Card(Ace, Clubs)
        };
        
        var deckBuilder = Given.A<Mock<IDeckBuilder>>()
            .ThatReturns(cardCollection, forNumberOfPacks: selectedOptions.NumberOfPacksToUse);

        var fixture = new Fixture();
        fixture.Register(() => deckBuilder.Object);
        fixture.Register<IPlayerBuilder>(() => new PlayerBuilder());
        fixture.Register(() => Console.Out);
        _gameState = fixture.Create<GameState>();
        fixture.Register(() => _gameState);
        
        var game = fixture.Create<Game>();
        game.PlayNewGameWithOptions(selectedOptions);
    }

    [Test]
    public void ItShouldHaveNoMoreCardsInTheDeck()
    {
        _gameState.Deck.Should().BeEmpty();
    }
    
    [Test]
    public void TheDeclaringPlayerShouldWinTheAccruedCardsInThePile()
    {
        var declaringPlayer = _gameState.Players.First(player => player.Winnings.Count > 0);
        declaringPlayer.Winnings.Should().ContainInOrder(new Card(Two, Diamonds), new Card(Three, Diamonds), new Card(Ace, Clubs));
    }
}