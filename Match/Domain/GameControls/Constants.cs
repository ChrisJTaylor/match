namespace Match.Domain.GameControls;

public static class Constants
{
    public static class Questions
    {
        public static readonly string HowManyPacksOfCardsToUse = "How many packs of cards would you like? (1 - 9)";
        public static readonly string WhichMatchingTypeWouldYouLikeToUse = "Which matching type would you like to use? (1 = Value, 2 = Suite, 3 = Value and Suite)";
    }

    public static class Responses
    {
        public static readonly string YouMustEnterANumberBetween1And9 = "You must enter a number between 1 and 9";
        public static readonly string YouMustEnterANumberBetween1And3 = "You must enter a number between 1 and 3";
    }
}