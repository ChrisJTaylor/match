namespace Match.Domain.GameControls;

public static class InputConvenienceExtensions {

    public static bool IsBetween(this int source, int from, int to)
    {
        return source >= from && source <= to;
    }
}