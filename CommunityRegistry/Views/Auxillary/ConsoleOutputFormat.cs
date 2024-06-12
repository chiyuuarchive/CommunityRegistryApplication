namespace CommunityRegistry.Views.Auxillary
{

    public enum FontTheme
    {
        Default,
        Error,
        Success
    }

    public static class ConsoleOutputFormat
    {
        public static void ChangeFontColor(FontTheme theme)
        {
            switch (theme)
            {
                case FontTheme.Error:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case FontTheme.Success:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
    }
}
