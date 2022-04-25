namespace Match.Domain.GameRoutine;

public class Adjudicator
{
    private readonly IGameState _gameState;
    private readonly TextWriter _consoleOut;

    public Adjudicator(IGameState gameState, TextWriter consoleOut)
    {
        _gameState = gameState;
        _consoleOut = consoleOut;
    }
    public void DeclareTheResult()
    {
        var winner = _gameState.Players.OrderByDescending(player => 
            player.Winnings.Count).First();

        var message = $"{winner.Name} is the winner with {winner.Winnings.Count} cards!";
        
        if (_gameState.Players.All(player => player.Winnings.Count == winner.Winnings.Count))
        {
            message = $"The game is a draw with {_gameState.Players.First().Winnings.Count} cards each!";
        }
        
        _consoleOut.WriteLine(message);
    }
}