using Match.Domain;

namespace Match.GameRoutine;

public class Player
{
    public Player(string name)
    {
        Name = name;
        Pile = Array.Empty<Card>();
    }
    public string Name { get; }
    public Card[] Pile { get; }
}