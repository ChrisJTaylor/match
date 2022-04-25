using Match.Domain.GameRoutine;
using Match.Domain.GameSetup;

namespace Match.Domain;
public class Game
{
    private readonly IGameState _gameState;

    public Game(IGameState gameState)
    {
        _gameState = gameState;
    }
    
    public void PlayNewGameWithOptions(GameOptions selectedOptions)
    {
        _gameState.InitialiseStateWithOptions(selectedOptions);
        
        while (GameCanContinue())
        {
            PlayRound(selectedOptions);
        }
    }

    private void PlayRound(GameOptions selectedOptions)
    {
        if (_gameState.Pile.TryPeek(out var previousCard))
        {
            previousCard = _gameState.Pile.Peek();
        }

        var cardInPlay = _gameState.Deck.Pop();
        _gameState.Pile.Push(cardInPlay);

        if (!cardInPlay.IsAMatchFor(previousCard, selectedOptions.SelectedMatchingCondition)) return;
        
        var player = ListenForMatchDeclarations();
        if (!player.HasValue) return;
            
        Console.WriteLine(player.Value.Name);
        player?.Winnings.AddRange(_gameState.Pile.ToArray());
        _gameState.Pile.Clear();
    }

    private Player? ListenForMatchDeclarations()
    {
        var rnd = new Random(DateTime.Now.Millisecond);
        return _gameState.Players[rnd.Next(0, _gameState.Players.Length)];
    }

    private bool GameCanContinue()
    {
        return _gameState.Deck.Count > 0;
    }
}