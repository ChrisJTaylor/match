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

    public void PlayNewGameWithOptions(GameOptions selectedOptions)
    {
        Players = _playerBuilder.BuildPlayers();
        
        var deck =_deckBuilder.BuildDeckUsingNumberOfPacks(selectedOptions.NumberOfPacksToUse);
        Deck = new Stack<Card>(deck);

        while (GameCanContinue())
        {
            PlayRound(selectedOptions);
        }
    }

    private void PlayRound(GameOptions selectedOptions)
    {
        if (Pile.TryPeek(out var previousCard))
        {
            previousCard = Pile.Peek();
        }

        var cardInPlay = Deck.Pop();
        Pile.Push(cardInPlay);

        if (cardInPlay.IsAMatchFor(previousCard, selectedOptions.SelectedMatchingCondition))
        {
            var player = ListenForMatchDeclarations();
            if (player.HasValue)
            {
                Console.WriteLine(player.Value.Name);
                player?.Winnings.AddRange(Pile.ToArray());
                Pile.Clear();
            }
        }
    }

    private Player? ListenForMatchDeclarations()
    {
        var rnd = new Random(DateTime.Now.Millisecond);
        return Players[rnd.Next(0, Players.Length)];
    }

    private bool GameCanContinue()
    {
        return Deck.Count > 0;
    }
}