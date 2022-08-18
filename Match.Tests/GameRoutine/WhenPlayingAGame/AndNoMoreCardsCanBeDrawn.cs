namespace Match.Tests.GameRoutine.WhenPlayingAGame;

using TestHelpers;

public class AndNoMoreCardsCanBeDrawn
{
    private IGameState _gameState = null!;
    private Card[] _cardCollection = null!;
    
    [OneTimeSetUp]
    public void WhenAGameIsComingToAClose()
    {
        var selectedOptions = new GameOptions(1, CardValueAndSuit);
        
        _cardCollection = new[]
        {
            new Card(Ace, Clubs),
            new Card(Three, Diamonds)
        };
        
        var deckBuilder = Given.A<Mock<IDeckBuilder>>()
            .ThatReturns(_cardCollection, forNumberOfPacks: selectedOptions.NumberOfPacksToUse);

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
    public void ItShouldPopulateThePileFromCardsTakenFromTheDeck()
    {
        _gameState.Pile.Should().ContainInOrder(_cardCollection);
    }
}