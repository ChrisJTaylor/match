namespace Match.Tests.GameSetup;

using TestHelpers;

public class WhenBuildingPlayers
{
    private Player[] _players = Array.Empty<Player>();

    [OneTimeSetUp]
    public void SetUp()
    {
        _players = Given.Create<PlayerBuilder>().BuildPlayers();
    }

    [Test]
    public void ItShouldHaveExpectedNumberOfPlayers()
    {
        _players.Should().HaveCount(2);
    }

    [Test]
    public void PlayersShouldHaveExpectedNames()
    {
        _players.Should().Contain(player => player.Name == "Jack");
        _players.Should().Contain(player => player.Name == "Jill");
    }

    [Test]
    public void PlayersShouldNotHaveAnyWinnings()
    {
        _players.Should().OnlyContain(player => player.Winnings.Count == 0);
    }
}