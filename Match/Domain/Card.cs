namespace Match.Domain;

public struct Card
{
    public CardValues Value { get; }
    public CardSuits Suit { get; }

    public Card(CardValues value, CardSuits suit)
    {
        Value = value;
        Suit = suit;
    }

    public bool IsAMatchFor(Card comparisonCard, MatchingCondition matchingBy)
    {
        var comparisonResult = false;
        switch (matchingBy)
        {
            case MatchingCondition.CardValue:
                 comparisonResult = Value == comparisonCard.Value;
                break;
            case MatchingCondition.Suit:
                 comparisonResult = Suit == comparisonCard.Suit;
                break;
            case MatchingCondition.CardValueAndSuit:
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