using Match.Domain;

namespace Match.GameRoutine;
public class Game
{
    public Game()
    {
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
        Deck = BuildDeckWith(numberOfPacks: selectedOptions.NumberOfPacksToUse);
    }
    private static Card[] BuildDeckWith(int numberOfPacks)
    {
        var deck = new List<Card>(); 
        for (var iteration = 1; iteration <= numberOfPacks; iteration++)
        {
            deck.AddRange(Pack.Cards);
        }

        return deck.ToArray();
    }
}