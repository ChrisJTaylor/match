using Match.Domain.GameRoutine;

namespace Match.Domain.Cards;

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
        var comparisonResult = matchingBy switch
        {
            MatchingCondition.CardValue => Value == comparisonCard.Value,
            MatchingCondition.Suit => Suit == comparisonCard.Suit,
            MatchingCondition.CardValueAndSuit => Value == comparisonCard.Value && Suit == comparisonCard.Suit,
            _ => false
        };
        return comparisonResult;
    }

    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}