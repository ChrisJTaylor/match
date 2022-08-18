namespace Match.Tests.TestHelpers;

using System.Collections.Generic;
using Domain.GameControls;
using static KeyboardInputHelperExtensions;

public static class Given
{
    public static TType Create<TType>() where TType : new()
    {
        return new TType();
    }
    
    public static Player PlayerNamed(string name)
    {
        return new Player(name);
    }

    public static Player WithWinnings(this Player player, IEnumerable<Card> cardsWon)
    {
        foreach (var card in cardsWon)
        {
            player.Winnings.Add(card);
        }
        return player;
    }

    public static Mock<IPlayerBuilder> WithPlayers(this Mock<IPlayerBuilder> playerBuilder, Player[] players)
    {
        playerBuilder.Setup(builder =>
                builder.BuildPlayers())
            .Returns(players);
        return playerBuilder;
    }

    public static Mock<IDeckBuilder> ThatReturns(this Mock<IDeckBuilder> deckBuilder, Card[] cardsToReturn,
        int forNumberOfPacks)
    {
        deckBuilder.Setup(builder => 
                builder.BuildDeckUsingNumberOfPacks(forNumberOfPacks))
            .Returns(cardsToReturn);
        return deckBuilder;
    }

    public static Mock<IKeyboardInput> ThatPressesKey(this Mock<IKeyboardInput> keyboardInput, char keyPressed)
    {
        keyboardInput.Setup(key => key.ReceiveInput()).Returns(KeyFor(keyPressed));
        return keyboardInput;
    }
}