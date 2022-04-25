namespace Match.Domain.GameRoutine;

public class Adjudicator
{
    private readonly IGameState _gameState;
    public Adjudicator(IGameState gameState)
    {
        _gameState = gameState;
    }
    public string DetermineTheWinner()
    {
        return _gameState.Players.First().Winnings.Count == _gameState.Players.Last().Winnings.Count 
            ? "no one" 
            : _gameState.Players.OrderByDescending(player => 
                player.Winnings.Count).First().Name;
    }
}