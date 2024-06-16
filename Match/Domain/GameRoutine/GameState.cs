using Match.Domain.Cards;
using Match.Domain.GameSetup;

namespace Match.Domain.GameRoutine;

public class GameState : IGameState
{
    private readonly IDeckBuilder _deckBuilder;
    private readonly IPlayerBuilder _playerBuilder;

    public GameState(IDeckBuilder deckBuilder, IPlayerBuilder playerBuilder)
    {
        _deckBuilder = deckBuilder;
        _playerBuilder = playerBuilder;

        Deck = new Stack<Card>();
        Pile = new Stack<Card>();

        Players = Array.Empty<Player>();

        Options = new GameOptions(0, MatchingCondition.None);
    }

    public GameOptions Options { get; private set; }
    public Stack<Card> Deck { get; private set; }
    public Stack<Card> Pile { get; }
    public Player[] Players { get; private set; }

    public void InitialiseStateWithOptions(GameOptions selectedOptions)
    {
        Options = selectedOptions;
        Players = _playerBuilder.BuildPlayers();
        
        var deck =_deckBuilder.BuildDeckUsingNumberOfPacks(selectedOptions.NumberOfPacksToUse);
        Deck = new Stack<Card>(deck);
    }

}
