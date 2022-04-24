using Match.Domain.Cards;
using Match.Domain.GameSetup;

namespace Match.Domain;
public class Game
{
    private readonly IDeckBuilder _deckBuilder;
    private readonly IPlayerBuilder _playerBuilder;

    public Game(IDeckBuilder deckBuilder, IPlayerBuilder playerBuilder)
    {
        _deckBuilder = deckBuilder;
        _playerBuilder = playerBuilder;

        Deck = new Stack<Card>();
        Pile = new Stack<Card>();

        Players = Array.Empty<Player>();
    }
    
    public Stack<Card> Deck { get; private set; }
    public Player[] Players { get; private set; }
    public Stack<Card> Pile { get; }

    public void StartNewGameWithOptions(GameOptions selectedOptions)
    {
        Players = _playerBuilder.BuildPlayers();
        
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
}