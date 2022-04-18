namespace Match.Domain;

public static class HelperExtensions {

    public static bool IsBetween(this int source, int from, int to)
    {
        return source >= from && source <= to;
    }
}