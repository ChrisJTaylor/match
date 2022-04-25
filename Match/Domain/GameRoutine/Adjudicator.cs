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
        const string draw = "no one";
        var result = _gameState.Players.First().Winnings.Count == _gameState.Players.Last().Winnings.Count 
            ?  draw
            : _gameState.Players.OrderByDescending(player => 
                player.Winnings.Count).First().Name;

        var message = result == draw
            ? "The game is a draw!"
            : $"{result} is the winner!";
        
        _consoleOut.WriteLine(message);
    }
}