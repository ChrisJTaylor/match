namespace Match.Tests.GameRoutine.WhenDecidingTheWinner;

using TestHelpers;

public class AndItIsADraw
{
    private readonly StringBuilder _consoleOut = new();

    [OneTimeSetUp]
    public void WhenBothPlayersHaveTheSameScore()
    {
        var selectedOptions = new GameOptions(1, CardValueAndSuit);
        
        var deckBuilder = Given.Create<Mock<IDeckBuilder>>()
            .ThatReturns(Array.Empty<Card>(), forNumberOfPacks: selectedOptions.NumberOfPacksToUse);

        var playerBuilder = Given.Create<Mock<IPlayerBuilder>>()
            .WithPlayers(new[] 
            {
                Given.PlayerNamed("Bill").WithWinnings(new [] 
                { 
                    new Card(Ace, Diamonds), 
                    new Card(Ace, Diamonds) 
                }), 
                Given.PlayerNamed("Ben").WithWinnings(new [] 
                { 
                    new Card(Three, Clubs), 
                    new Card(Three, Clubs) 
                })
            });
        
        var fixture = new Fixture();
        fixture.Register(() => deckBuilder.Object);
        fixture.Register(() => playerBuilder.Object);
        fixture.Register<TextWriter>(() => new StringWriter(_consoleOut));
        var gameState = fixture.Create<GameState>();
        fixture.Register<IGameState>(() => gameState);
        
        var game = fixture.Create<Game>();
        game.PlayNewGameWithOptions(selectedOptions);
    }

    [Test]
    public void ItShouldDeclareTheGameADraw()
    {
        _consoleOut.ToString().Should().Contain($"The game is a draw with 2 cards each!");
    }
}