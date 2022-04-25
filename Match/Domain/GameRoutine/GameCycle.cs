using static Match.Domain.GameSetup.Utility;

namespace Match.Domain.GameRoutine;
public class GameCycle
{
    private readonly IGameState _gameState;
    
    public GameCycle(IGameState gameState)
    {
        _gameState = gameState;
    }

    public void PlayRound()
    {
        if (_gameState.Pile.TryPeek(out var previousCard))
        {
            previousCard = _gameState.Pile.Peek();
        }

        var cardInPlay = _gameState.Deck.Pop();
        _gameState.Pile.Push(cardInPlay);

        if (cardInPlay.IsAMatchFor(previousCard, _gameState.Options.SelectedMatchingCondition))
        {
            var player = ListenForMatchDeclarations();
            if (player.HasValue)
            {
                Console.WriteLine(player.Value.Name);
                player?.Winnings.AddRange(_gameState.Pile.ToArray());
                _gameState.Pile.Clear();
            }
        }
    }
    private Player? ListenForMatchDeclarations()
    {
        return _gameState.Players[GetRandomiser().Next(0, _gameState.Players.Length)];
    }
}