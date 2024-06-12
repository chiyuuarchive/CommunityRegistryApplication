using CommunityRegistry.Data;
using CommunityRegistry.Models;
using CommunityRegistry.Authentication;
using CommunityRegistry.Views.Auxillary;

namespace CommunityRegistry.Views
{
    internal class LoginView : IView
    {
        IFieldValidator validator = null;
        ILogin login = null;
        
        public IFieldValidator FieldValidator => validator;
        public LoginView(ILogin login, IFieldValidator validator)
        {
            this.login = login;
            this.validator = validator;
        }

        public void RunViewBackup()
        {
            ConsoleOutputHeadings.PrintMainHeading();

            ConsoleOutputHeadings.PrintLoginHeading();
            Console.WriteLine("Please enter your email");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();

            Member member = login.Login(email, password);
            if (member != null)
            {
                // Run welcome view
                WelcomeView view = new WelcomeView(member);
                view.RunView();
            }
            else
            {
                Console.Clear();
                ConsoleOutputFormat.ChangeFontColor(FontTheme.Error);
                Console.WriteLine("The credentials that you entered do not match our records");
                ConsoleOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();
            }
        }

        public void RunView()
        {
            ConsoleOutputHeadings.PrintMainHeading();
            ConsoleOutputHeadings.PrintLoginHeading();
            validator.FieldArray[(int)FieldTypes.UserLoginField.Email] = GetInputFromUser(FieldTypes.UserLoginField.Email, "Please enter your email: ");
            validator.FieldArray[(int)FieldTypes.UserLoginField.Password] = GetInputFromUser(FieldTypes.UserLoginField.Password, "Enter your password: ");

            string validEmail = validator.FieldArray[(int)FieldTypes.UserLoginField.Email];
            string validPassword = validator.FieldArray[(int)FieldTypes.UserLoginField.Password];
            TryLoginWith(validEmail, validPassword);
        }

        private string GetInputFromUser(FieldTypes.UserLoginField field, string prompt)
        {
            string fieldValue = string.Empty;
            do
            {
                Console.WriteLine(prompt);
                fieldValue = Console.ReadLine();
            } while (!FieldValid(field, fieldValue));

            return fieldValue;
        }

        private bool FieldValid(FieldTypes.UserLoginField field, string fieldValue)
        {
            if (!validator.Validator((int)field, fieldValue, validator.FieldArray, out string invalidMessage))
            {
                Console.Clear();
                ConsoleOutputHeadings.PrintMainHeading();
                ConsoleOutputHeadings.PrintLoginHeading();

                ConsoleOutputFormat.ChangeFontColor(FontTheme.Error);
                Console.WriteLine(invalidMessage);
                ConsoleOutputFormat.ChangeFontColor(FontTheme.Default);
                return false;
            }

            return true;
        }

        private void TryLoginWith(string email, string password)
        {
            Member member = login.Login(email, password);
            if (member != null)
            {
                // Run welcome view
                WelcomeView view = new WelcomeView(member);
                view.RunView();
            }
            else
            {
                Console.Clear();
                ConsoleOutputFormat.ChangeFontColor(FontTheme.Error);
                Console.WriteLine("The credentials that you entered do not match our records");
                ConsoleOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();
            }
        }
    }
}
