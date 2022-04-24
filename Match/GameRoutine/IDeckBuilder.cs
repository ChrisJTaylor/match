using Match.Domain;

namespace Match.GameRoutine;

public interface IDeckBuilder
{
    Card[] BuildDeckUsingNumberOfPacks(int numberOfPacks);
}