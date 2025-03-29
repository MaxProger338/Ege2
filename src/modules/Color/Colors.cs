using Spectre.Console;

namespace Victory
{
    static class Colors
    {
        public static string Format(ConsoleColor color, string text)
        {
            return $"[{color}]{text}[/]";
        }

        public static string Format(string color, string text)
        {
            return $"[{color}]{text}[/]";
        }

        public static void Print(ConsoleColor color, string text)
        {
            AnsiConsole.Markup(Format(color, text));
        }

        public static void Print(string color, string text)
        {
            AnsiConsole.Markup(Format(color, text));
        }
    }
}