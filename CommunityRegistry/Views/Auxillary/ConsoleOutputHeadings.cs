namespace CommunityRegistry.Views
{
    public static class ConsoleOutputHeadings
    {
        private static string MainHeading
        {
            get
            {
                string heading = "Regentag Community";
                return $"{heading}\n{new string('-', heading.Length)}";
            }
        }

        private static string RegistrationHeading
        {
            get
            {
                string heading = "Register";
                return $"{heading}\n{new string('-', heading.Length)}";
            }
        }

        private static string LoginHeading
        {
            get
            {
                string heading = "Login";
                return $"{heading}\n{new string('-', heading.Length)}";
            }
        }

        public static void PrintMainHeading()
        {
            Console.Clear();
            Console.WriteLine(MainHeading);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PrintRegistrationHeading()
        {
            Console.Clear();
            PrintMainHeading();
            Console.WriteLine(RegistrationHeading);
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void PrintLoginHeading()
        {
            Console.Clear();
            PrintMainHeading();
            Console.WriteLine(LoginHeading);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
