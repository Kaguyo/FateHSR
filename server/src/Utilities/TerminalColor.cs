namespace server.src.Utilities;

public static class TerminalColor
{
    public static void SetOutputColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }
    
    public static void ResetOutputColor()
    {
        Console.ResetColor();
    }
}
