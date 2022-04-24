namespace Match.Domain.GameSetup;

public class PlayerBuilder : IPlayerBuilder
{
    public Player[] BuildPlayers()
    {
        return new[]
        {
            new Player("Jack"),
            new Player("Jill")
        };
    }
}