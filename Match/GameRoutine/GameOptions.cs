using Match.Domain;

namespace Match.GameRoutine;
public class GameOptions
{
    public GameOptions(int numberOfPacks, MatchCondition selectedMatchCondition)
    {
        NumberOfPacksToUse = numberOfPacks;
        SelectedMatchingCondition = selectedMatchCondition;
    }
    
    public int NumberOfPacksToUse { get; }
    public MatchCondition SelectedMatchingCondition { get; }
}