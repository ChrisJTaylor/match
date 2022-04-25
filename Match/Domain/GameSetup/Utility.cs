namespace Match.Domain.GameSetup;

public static class Utility
{
    public static Random GetRandomiser()
    {
        Thread.Sleep(TimeSpan.FromMilliseconds(4));
        return new Random(DateTime.Now.Millisecond);
    }
}