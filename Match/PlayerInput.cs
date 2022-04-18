using System.Globalization;
using static Match.Constants;

namespace Match;

public class PlayerInput
{
    private readonly StringWriter _consoleWriter;
    private readonly IKeyboardInput _keyboardInput;

    public PlayerInput(StringWriter consoleWriter, IKeyboardInput keyboardInput)
    {
        _consoleWriter = consoleWriter;
        _keyboardInput = keyboardInput;
    }

    public int AskPlayerHowManyPacksOfCardsToUse()
    {
        _consoleWriter.WriteLine(HowManyPacksOfCardsToUse);

        var key = _keyboardInput.ReceiveInput();

        if (int.TryParse(key.KeyChar.ToString(), out var numberOfPacks))
        {
            return numberOfPacks;
        }

        throw new InvalidInputException(YouMustEnterANumberBetween1And9);
    }
}