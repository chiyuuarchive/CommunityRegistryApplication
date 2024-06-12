using CommunityRegistry.Models;
using CommunityRegistry.Authentication;
using CommunityRegistry.Views.Auxillary;

namespace CommunityRegistry.Views
{
    internal class WelcomeView:IView
    {
        Member member = null;

        public WelcomeView(Member member) => this.member = member;

        // No validation
        public IFieldValidator FieldValidator => null;

        public void RunView()
        {
            Console.Clear();
            ConsoleOutputHeadings.PrintMainHeading();
            ConsoleOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"Welcome back {member.FirstName}.\nThe Regentag Community is at your service");
            ConsoleOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.ReadKey();
        }
    }
}
