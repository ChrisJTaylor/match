using Match.Domain.GameRoutine;
using static Match.Domain.GameControls.Constants.Questions;
using static Match.Domain.GameControls.Constants.Responses;

namespace Match.Domain.GameControls;

public class PlayerInput
{
    private readonly TextWriter _consoleWriter;
    private readonly IKeyboardInput _keyboardInput;

    public PlayerInput(TextWriter consoleWriter, IKeyboardInput keyboardInput)
    {
        _consoleWriter = consoleWriter;
        _keyboardInput = keyboardInput;
    }

    public int AskPlayerHowManyPacksOfCardsToUse()
    {
        _consoleWriter.WriteLine(HowManyPacksOfCardsToUse);

        var key = _keyboardInput.ReceiveInput();

        if (PlayerSelectedAValidNumberOfPacks(key, out var numberOfPacks))
        {
            return numberOfPacks;
        }

        throw new InvalidInputException(YouMustEnterANumberBetween1And9);
    }

    public MatchingCondition AskPlayerWhichMatchingConditionToUse()
    {
        _consoleWriter.WriteLine(WhichMatchingConditionWouldYouLikeToUse);
        
        var key = _keyboardInput.ReceiveInput();

        if (PlayerEnteredAValidMatchingCondition(key, out var matchingCondition))
        {
            return (MatchingCondition)matchingCondition;
        }

        throw new InvalidInputException(YouMustEnterANumberBetween1And3);
    }

    private static bool PlayerSelectedAValidNumberOfPacks(ConsoleKeyInfo key, out int numberOfPacks)
    {
        return int.TryParse(key.KeyChar.ToString(), out numberOfPacks) 
               && numberOfPacks.IsBetween(1, to: 9);
    }
    
    private static bool PlayerEnteredAValidMatchingCondition(ConsoleKeyInfo key, out int matchingType)
    {
        return int.TryParse(key.KeyChar.ToString(), out matchingType)
               && matchingType.IsBetween(1, to: 3);
    }
}