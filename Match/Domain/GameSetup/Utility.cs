namespace Match.Domain.GameSetup;

public static class Utility
{
    public static Random GetRandomiser()
    {
        return new Random(DateTime.Now.Millisecond);
    }
}