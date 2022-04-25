namespace Match.Domain.GameRoutine;

public class Adjudicator
{
    public string DetermineTheWinnerOfTheGame(Game game)
    {
        return game.Players.First().Winnings.Count == game.Players.Last().Winnings.Count 
            ? "no one" 
            : game.Players.OrderByDescending(player => 
                player.Winnings.Count).First().Name;
    }
}