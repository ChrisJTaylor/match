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

    public bool IsAMatchFor(Card comparisonCard, MatchCondition matchingBy)
    {
        switch (matchingBy)
        {
            case MatchCondition.CardValue:
                return Value == comparisonCard.Value;
                break;
            case MatchCondition.Suit:
                return Suit == comparisonCard.Suit;
            case MatchCondition.CardValueAndSuit:
                return Value == comparisonCard.Value && Suit == comparisonCard.Suit;
        }
        return false;
    }

    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}