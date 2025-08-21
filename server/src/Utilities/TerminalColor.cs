namespace server.src.Utilities;

public static class TerminalColor
{
    public static void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public static void ResetColor()
    {
        Console.ResetColor();
    }
}
