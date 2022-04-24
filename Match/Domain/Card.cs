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
        var comparisonResult = false;
        switch (matchingBy)
        {
            case MatchCondition.CardValue:
                 comparisonResult = Value == comparisonCard.Value;
                break;
            case MatchCondition.Suit:
                 comparisonResult = Suit == comparisonCard.Suit;
                break;
            case MatchCondition.CardValueAndSuit:
                 comparisonResult = Value == comparisonCard.Value && Suit == comparisonCard.Suit;
                break;
        }
        return  comparisonResult;
    }

    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}