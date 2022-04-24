namespace Match.Domain;

public struct Card
{
    public CardValueEnum Value { get; }
    public CardSuitEnum Suit { get; }

    public Card(CardValueEnum value, CardSuitEnum suit)
    {
        Value = value;
        Suit = suit;
    }

    public bool IsAMatchFor(Card comparisonCard, MatchingTypeEnum matchingBy)
    {
        switch (matchingBy)
        {
            case MatchingTypeEnum.CardValue:
                return Value == comparisonCard.Value;
                break;
            case MatchingTypeEnum.Suit:
                return Suit == comparisonCard.Suit;
        }
        return false;
    }

    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}