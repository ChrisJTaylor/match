using System;

namespace Match.Tests.GameSetup.TestHelpers;

public static class KeyboardInputHelperExtensions
{
    public static ConsoleKeyInfo KeyFor(char key)
    {
        var consoleKey = Enum.Parse<ConsoleKey>(key.ToString());
        return new ConsoleKeyInfo(key, consoleKey, false, false, false);
    }
}