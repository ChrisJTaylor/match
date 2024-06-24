using Match.Domain.Cards;
using static Match.Domain.GameSetup.Utility;

namespace Match.Domain.GameRoutine;
public class GameCycle
{
    private readonly IGameState _gameState;
    private readonly TextWriter _consoleOut;
    private readonly Random _random;
    
    public GameCycle(IGameState gameState, TextWriter consoleOut)
    {
        _gameState = gameState;
        _consoleOut = consoleOut;
        _random = GetRandomiser();
    }

    public void PlayRound()
    {
        if (_gameState.Pile.TryPeek(out var previousCard))
        {
            previousCard = _gameState.Pile.Peek();
        }

        var cardInPlay = _gameState.Deck.Pop();
        _gameState.Pile.Push(cardInPlay);
        
        _consoleOut.WriteLine($"Card in play is {cardInPlay}");

        if (TheCardsMatch(cardInPlay, previousCard)
            && APlayerDeclaresMatch(out var player))
        {
            _consoleOut.WriteLine($"{cardInPlay} matches {previousCard}!");
            _consoleOut.WriteLine($"{player.Name} wins {_gameState.Pile.Count} cards!");
            
            player.Winnings.AddRange(_gameState.Pile.ToArray());
            _gameState.Pile.Clear();
            
            _consoleOut.WriteLine();
        }
    }

    private bool TheCardsMatch(Card cardInPlay, Card previousCard)
    {
        return cardInPlay.IsAMatchFor(previousCard, _gameState.Options.SelectedMatchingCondition);
    }

    private bool APlayerDeclaresMatch(out Player playerDeclaringMatch)
    {
        playerDeclaringMatch = _gameState.Players.OrderBy(_ => _random.Next()).First();
        _consoleOut.WriteLine($"{playerDeclaringMatch.Name} declares match!");
        return true;
    }
}
