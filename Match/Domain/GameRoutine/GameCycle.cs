using Match.Domain.Cards;
using static Match.Domain.GameSetup.Utility;

namespace Match.Domain.GameRoutine;
public class GameCycle
{
    private readonly IGameState _gameState;
    private readonly Random _random;
    
    public GameCycle(IGameState gameState)
    {
        _gameState = gameState;
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

        if (APlayerDeclaresMatch(out var player) 
            && TheCardsMatch(cardInPlay, previousCard))
        {
            player.Winnings.AddRange(_gameState.Pile.ToArray());
            _gameState.Pile.Clear();
        }
    }

    private bool TheCardsMatch(Card cardInPlay, Card previousCard)
    {
        var result = cardInPlay.IsAMatchFor(previousCard, _gameState.Options.SelectedMatchingCondition);
        return result;
    }

    private bool APlayerDeclaresMatch(out Player playerDeclaringMatch)
    {
        playerDeclaringMatch = _gameState.Players.OrderBy(_ => _random.Next()).First();
        return true;
    }
}