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

        if (int.TryParse(key.KeyChar.ToString(), out var numberOfPacks) 
            && numberOfPacks.IsBetween(1, to: 9))
        {
            return numberOfPacks;
        }

        throw new InvalidInputException(YouMustEnterANumberBetween1And9);
    }

    public MatchingCondition AskPlayerWhichMatchingConditionToUse()
    {
        _consoleWriter.WriteLine(WhichMatchingConditionWouldYouLikeToUse);
        
        var key = _keyboardInput.ReceiveInput();

        if (int.TryParse(key.KeyChar.ToString(), out var matchingType)
            && matchingType.IsBetween(1, to: 3))
        {
            return (MatchingCondition)matchingType;
        }

        throw new InvalidInputException(YouMustEnterANumberBetween1And3);
    }

}