using Match.Domain.GameRoutine;

namespace Match.Domain.GameSetup;
public class GameOptions
{
    public GameOptions(int numberOfPacks, MatchingCondition selectedMatchingCondition)
    {
        NumberOfPacksToUse = numberOfPacks;
        SelectedMatchingCondition = selectedMatchingCondition;
    }
    
    public int NumberOfPacksToUse { get; }
    public MatchingCondition SelectedMatchingCondition { get; }
}