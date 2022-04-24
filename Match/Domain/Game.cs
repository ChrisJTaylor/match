using Match.Domain.Cards;
using Match.Domain.GameSetup;

namespace Match.Domain;
public class Game
{
    private readonly IDeckBuilder _deckBuilder;

    public Game(IDeckBuilder deckBuilder)
    {
        _deckBuilder = deckBuilder;
        
        Deck = Array.Empty<Card>();
        Players = BuildPlayers();
    }

    private static Player[] BuildPlayers()
    {
        return new[]
        {
            new Player("Jack"),
            new Player("Jill")
        };
    }
    
    public Card[] Deck { get; private set; }
    public Player[] Players { get; set; }

    public void SetupNewGameWithOptions(GameOptions selectedOptions)
    {
        Deck = _deckBuilder.BuildDeckUsingNumberOfPacks(selectedOptions.NumberOfPacksToUse);
    }
}