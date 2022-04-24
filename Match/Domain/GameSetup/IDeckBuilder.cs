using Match.Domain.Cards;

namespace Match.Domain.GameSetup;

public interface IDeckBuilder
{
    Card[] BuildDeckUsingNumberOfPacks(int numberOfPacks);
}