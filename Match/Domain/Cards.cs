using System.Collections.Generic;
using System.Linq;
using Match.Domain;

namespace Match.Tests;

public class Cards
{
    private readonly Card[] _pack;

    public Cards()
    {
        _pack = BuildPackOfCards().ToArray();
    }
    
    public Card[] Pack => _pack;
    private CardSuiteEnum[] Suites => new[] { CardSuiteEnum.Clubs, CardSuiteEnum.Diamonds };
    private CardValueEnum[] Values => new[] { CardValueEnum.One, CardValueEnum.Two, CardValueEnum.Three };

    private IEnumerable<Card> BuildPackOfCards()
    {
        foreach (var suite in Suites)
        {
            foreach (var value in Values)
            {
                yield return new Card(value, suite);
            } 
        }
    }
}