using Match.Domain.Cards;
using Match.Domain.GameSetup;

namespace Match.Domain;
public class Game
{
    private readonly IDeckBuilder _deckBuilder;

    public Game(IDeckBuilder deckBuilder)
    {
        _deckBuilder = deckBuilder;

        Deck = new Stack<Card>();
        Pile = new Stack<Card>();
        
        Players = BuildPlayers();
    }
    
    public Stack<Card> Deck { get; private set; }
    public Player[] Players { get; }
    public Stack<Card> Pile { get; }

    public void StartNewGameWithOptions(GameOptions selectedOptions)
    {
        var deck =_deckBuilder.BuildDeckUsingNumberOfPacks(selectedOptions.NumberOfPacksToUse);
        Deck = new Stack<Card>(deck);

        while (GameCanContinue())
        {
            var cardInPlay = Deck.Pop();
            Pile.Push(cardInPlay);
        }
    }

    private bool GameCanContinue()
    {
        return Deck.Count > 0;
    }

    private static Player[] BuildPlayers()
    {
        return new[]
        {
            new Player("Jack"),
            new Player("Jill")
        };
    }
}