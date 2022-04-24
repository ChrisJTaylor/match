namespace Match.Domain;

public struct Card
{
    public CardValueEnum Value { get; }
    public CardSuiteEnum Suite { get; }

    public Card(CardValueEnum value, CardSuiteEnum suite)
    {
        Value = value;
        Suite = suite;
    }

    public bool IsAMatchFor(Card comparisonCard, MatchingTypeEnum matchingBy)
    {
        switch (matchingBy)
        {
            case MatchingTypeEnum.CardValue:
                return Value == comparisonCard.Value;
                break;
        }
        return false;
    }

    public override string ToString()
    {
        return $"{Value} of {Suite}";
    }
}