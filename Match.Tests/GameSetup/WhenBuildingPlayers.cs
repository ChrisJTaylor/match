namespace Match.Tests.GameSetup;

using System.Linq;
using TestHelpers;

public class WhenBuildingPlayers
{
    private Player[] _players = Array.Empty<Player>();

    [OneTimeSetUp]
    public void SetUp()
    {
        _players = Given.A<PlayerBuilder>().BuildPlayers();
    }

    [Test]
    public void ItShouldHaveExpectedNumberOfPlayers()
    {
        _players.Should().HaveCount(2);
    }

    [Test]
    public void PlayersShouldHaveUniqueNames()
    {
        _players.DistinctBy(player => player.Name).Should().HaveCount(2);
    }

    [Test]
    public void PlayersShouldNotHaveAnyWinnings()
    {
        _players.Should().OnlyContain(player => player.Winnings.Count == 0);
    }
}