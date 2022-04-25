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

        if (ListenForMatchDeclarations(out var player) 
            && TheCardsMatch(cardInPlay, previousCard))
        {
            player.Winnings.AddRange(_gameState.Pile.ToArray());
            _gameState.Pile.Clear();
        }
    }

    private bool TheCardsMatch(Card cardInPlay, Card previousCard)
    {
        return cardInPlay.IsAMatchFor(previousCard, _gameState.Options.SelectedMatchingCondition);
    }

    private bool ListenForMatchDeclarations(out Player playerDeclaringMatch)
    {
        playerDeclaringMatch = _gameState.Players[_random.Next(0, _gameState.Players.Length)];
        return true;
    }
}