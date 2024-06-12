using CommunityRegistry.Authentication;

namespace CommunityRegistry.Views
{
    internal class MainView : IView
    {
        public IFieldValidator FieldValidator => null;
        IView registerView = null;
        IView loginView = null;
        public MainView(IView registerView, IView loginView)
        {
            this.registerView = registerView;
            this.loginView = loginView;
        }

        public void RunView()
        {
            ConsoleOutputHeadings.PrintMainHeading();
            Console.WriteLine("Please press 'L' to login or 'R' if you want to register as a new member of the Regentag Community");

            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.L:
                    RunLoginView();
                    break;
                case ConsoleKey.R:
                    RunRegistrationView();
                    RunLoginView();
                    break;
                default:
                    Console.Clear();
                    string msg = "Your presence has been noted!";
                    Console.WriteLine($"{msg}\n{new string('-', msg.Length)}\nApplication is closing down...");
                    Console.ReadKey();
                    break;
            }
        }

        private void RunRegistrationView() => registerView.RunView();
        private void RunLoginView() => loginView.RunView();
    }
}
