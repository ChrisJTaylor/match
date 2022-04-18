using Match.Domain;

namespace Match.Tests;

public struct Card
{
    public CardValueEnum Value { get; }
    public CardSuiteEnum Suite { get; }

    public Card(CardValueEnum value, CardSuiteEnum suite)
    {
        Value = value;
        Suite = suite;
    } 
}