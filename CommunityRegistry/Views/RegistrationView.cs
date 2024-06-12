using CommunityRegistry.Data;
using CommunityRegistry.Authentication;
using CommunityRegistry.Views.Auxillary;

namespace CommunityRegistry.Views
{
    internal class RegistrationView : IView
    {
        IFieldValidator validator = null;
        IRegister register = null;
        public IFieldValidator FieldValidator => validator;

        public RegistrationView(IRegister register, IFieldValidator validator)
        {
            this.register = register;
            this.validator = validator;
        }
        public void RunView()
        {
            ConsoleOutputHeadings.PrintMainHeading();
            ConsoleOutputHeadings.PrintRegistrationHeading();

            validator.FieldArray[(int)FieldTypes.UserRegistrationField.FirstName] = GetInputFromUser(FieldTypes.UserRegistrationField.FirstName, "Please enter your first name: ");
            validator.FieldArray[(int)FieldTypes.UserRegistrationField.LastName] = GetInputFromUser(FieldTypes.UserRegistrationField.LastName, "Please enter your last name: ");
            validator.FieldArray[(int)FieldTypes.UserRegistrationField.Email] = GetInputFromUser(FieldTypes.UserRegistrationField.Email, "Please enter your email: ");
            validator.FieldArray[(int)FieldTypes.UserRegistrationField.Password] = GetInputFromUser(FieldTypes.UserRegistrationField.Password, "Please set your password (must have one uppercase, lowercase and digit): ");
            validator.FieldArray[(int)FieldTypes.UserRegistrationField.ComparePassword] = GetInputFromUser(FieldTypes.UserRegistrationField.ComparePassword, "Please confirm your password: ");
            validator.FieldArray[(int)FieldTypes.UserRegistrationField.Occupation] = GetInputFromUser(FieldTypes.UserRegistrationField.Occupation, "Please enter your current occupation: ");
            validator.FieldArray[(int)FieldTypes.UserRegistrationField.DateOfBirth] = GetInputFromUser(FieldTypes.UserRegistrationField.DateOfBirth, "Please enter your birthday: ");
            validator.FieldArray[(int)FieldTypes.UserRegistrationField.Birthplace] = GetInputFromUser(FieldTypes.UserRegistrationField.Birthplace, "Please enter your birthplace: ");

            RegisterApplication();
        }

        private void RegisterApplication()
        {
            register.Register(validator.FieldArray);

            ConsoleOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine("You have successfully registered. Please press any key to login");
            ConsoleOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.ReadKey();
        }

        private string GetInputFromUser(FieldTypes.UserRegistrationField field, string prompt)
        {
            string fieldValue = string.Empty;
            do
            {
                Console.Write(prompt);
                fieldValue = Console.ReadLine();
            }
            while (!FieldValid(field, fieldValue));

            return fieldValue;
        }

        private bool FieldValid(FieldTypes.UserRegistrationField field, string fieldValue)
        {
            if (!validator.Validator((int)field, fieldValue, validator.FieldArray, out string invalidMessage))
            {
                ConsoleOutputFormat.ChangeFontColor(FontTheme.Error);
                Console.WriteLine(invalidMessage);
                ConsoleOutputFormat.ChangeFontColor(FontTheme.Default);
                return false;
            }

            return true;
        }
    }
}
