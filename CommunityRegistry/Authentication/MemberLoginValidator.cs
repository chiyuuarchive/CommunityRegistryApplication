using AuthenticatorAPI;

namespace CommunityRegistry.Authentication
{
    internal class MemberLoginValidator : IFieldValidator
    {
        ValidateRequiredField validateRequiredField = null;
        ValidateMatchPattern validateMatchPattern = null;

        FieldValidator? fieldValidator = null;
        string[]? fieldArray = null;

        public FieldValidator Validator => fieldValidator;
        public string[] FieldArray
        {
            get
            {
                if (fieldArray == null) fieldArray = new string[Enum.GetValues(typeof(FieldTypes.UserLoginField)).Length];
                return fieldArray;
            }
        }

        public void InitializeValidatorDelegates()
        {
            fieldValidator = new FieldValidator(ValidateField);

            validateRequiredField = MemberFieldValidators.ValidateRequiredField;
            validateMatchPattern = MemberFieldValidators.ValidateMatchPattern;
        }

        private bool ValidateField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = string.Empty;

            FieldTypes.UserLoginField field = (FieldTypes.UserLoginField)fieldIndex;
            switch(field)
            {
                case FieldTypes.UserLoginField.Email:
                    fieldInvalidMessage = !validateRequiredField(fieldValue) ? $"Please enter a value for field {Enum.GetName(typeof(FieldTypes.UserLoginField), field)}\n" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !validateMatchPattern(fieldValue, RegexValidatorPatterns.EMAIL)) ? "Please enter a valid email\n" : fieldInvalidMessage;
                    break;
                case FieldTypes.UserLoginField.Password:
                    fieldInvalidMessage = !validateRequiredField(fieldValue) ? $"Please enter a value for field {Enum.GetName(typeof(FieldTypes.UserLoginField), field)}\n" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !validateMatchPattern(fieldValue, RegexValidatorPatterns.PASSWORD)) ? "Please enter a valid passowrd\n" : fieldInvalidMessage;
                    break;
            }

            return string.IsNullOrEmpty(fieldInvalidMessage);
        }
    }
}
