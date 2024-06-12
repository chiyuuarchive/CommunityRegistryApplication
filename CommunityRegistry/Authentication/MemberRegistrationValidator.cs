using AuthenticatorAPI;
using CommunityRegistry.Data;

namespace CommunityRegistry.Authentication
{

    internal class MemberRegistrationValidator : IFieldValidator
    {
        const int FirstNameMinLength = 2;
        const int FirstNameMaxLength = 50;
        const int LastNameMinLength = 3;
        const int LastNameMaxLength = 50;
        
        delegate bool ValidateEmailExistence(string email);

        ValidateRequiredField validateRequiredField = null;
        ValidateStringLength validateStringLength = null;
        ValidateDate validateDate = null;
        ValidateMatchPattern validateMatchPattern = null;
        ValidateMatchingFields validateMatchingFields = null;
        ValidateEmailExistence validateEmailExistence = null;

        FieldValidator? fieldValidator = null;
        string[]? fieldArray = null;
        IRegister register;

        public FieldValidator? Validator => fieldValidator;
        public string[] FieldArray
        {
            get
            {
                // Define an array with same size as number of user registration fields
                if (fieldArray == null) fieldArray = new string[Enum.GetValues(typeof(FieldTypes.UserRegistrationField)).Length];
                return fieldArray;
            }
        }

        public MemberRegistrationValidator(IRegister register)
        {
            this.register = register;
        }

        public void InitializeValidatorDelegates()
        {
            fieldValidator = new FieldValidator(ValidateField);
            validateEmailExistence = new ValidateEmailExistence(register.EmailExists);

            validateRequiredField = MemberFieldValidators.ValidateRequiredField;
            validateStringLength = MemberFieldValidators.ValidateStringLength;
            validateDate = MemberFieldValidators.ValidateDate;
            validateMatchPattern = MemberFieldValidators.ValidateMatchPattern;
            validateMatchingFields = MemberFieldValidators.ValidateMatchingFields;

        }

        private bool ValidateField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = string.Empty;

            FieldTypes.UserRegistrationField field = (FieldTypes.UserRegistrationField)fieldIndex;

            switch (field)
            {
                case FieldTypes.UserRegistrationField.FirstName:
                    fieldInvalidMessage = !validateRequiredField(fieldValue) ? $"Please enter a value for field: {Enum.GetName(typeof(FieldTypes.UserRegistrationField), field)}\n" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !validateStringLength(fieldValue, FirstNameMinLength, FirstNameMaxLength)) ? $"The length for field: {Enum.GetName(typeof(FieldTypes.UserRegistrationField), field)} must have {FirstNameMinLength}-{FirstNameMaxLength} letters\n" : fieldInvalidMessage;
                    break;
                case FieldTypes.UserRegistrationField.LastName:
                    fieldInvalidMessage = !validateRequiredField(fieldValue) ? $"Please enter a value for field: {Enum.GetName(typeof(FieldTypes.UserRegistrationField), field)}\n" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !validateStringLength(fieldValue, LastNameMinLength, LastNameMaxLength)) ? $"The length for field: {Enum.GetName(typeof(FieldTypes.UserRegistrationField), field)} must have {LastNameMinLength}-{LastNameMaxLength} letters\n" : fieldInvalidMessage;
                    break;
                case FieldTypes.UserRegistrationField.Email:
                    fieldInvalidMessage = !validateRequiredField(fieldValue) ? $"Please enter a value for field: {Enum.GetName(typeof(FieldTypes.UserRegistrationField), field)}\n" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !validateMatchPattern(fieldValue, RegexValidatorPatterns.EMAIL)) ? "Please enter a valid email\n" : fieldInvalidMessage;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && validateEmailExistence(fieldValue)) ? $"This email already exists\n" : fieldInvalidMessage;
                    break;
                case FieldTypes.UserRegistrationField.Password:
                    fieldInvalidMessage = !validateRequiredField(fieldValue) ? $"Please enter a value for field: {Enum.GetName(typeof(FieldTypes.UserRegistrationField), field)}\n" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !validateMatchPattern(fieldValue, RegexValidatorPatterns.PASSWORD)) ? "Must have 1 upper-, lowercase letter and 1 digit\n" : fieldInvalidMessage;
                    break;
                case FieldTypes.UserRegistrationField.ComparePassword:
                    fieldInvalidMessage = !validateRequiredField(fieldValue) ? $"Please enter a value for field: {Enum.GetName(typeof(FieldTypes.UserRegistrationField), field)}\n" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !validateMatchingFields(fieldValue, fieldArray[(int)FieldTypes.UserRegistrationField.Password])) ? "Your password entries don't match\n" : fieldInvalidMessage;
                    break;
                case FieldTypes.UserRegistrationField.Occupation:
                    fieldInvalidMessage = !validateRequiredField(fieldValue) ? $"Please enter a value for field: {Enum.GetName(typeof(FieldTypes.UserRegistrationField), field)}\n" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !validateMatchPattern(fieldValue, RegexValidatorPatterns.OCCUPATION)) ? "Invalid occupation. Accepts only letters\n" : fieldInvalidMessage;
                    break;
                case FieldTypes.UserRegistrationField.DateOfBirth:
                    fieldInvalidMessage = !validateRequiredField(fieldValue) ? $"Please enter a value for field: {Enum.GetName(typeof(FieldTypes.UserRegistrationField), field)}\n" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !validateDate(fieldValue, out DateTime validDateTime)) ? "Invalid date\n" : fieldInvalidMessage;
                    break;
                case FieldTypes.UserRegistrationField.Birthplace:
                    fieldInvalidMessage = !validateRequiredField(fieldValue) ? $"Please enter a value for field: {Enum.GetName(typeof(FieldTypes.UserRegistrationField), field)}\n" : string.Empty;
                    fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !validateMatchPattern(fieldValue, RegexValidatorPatterns.BIRTHPLACE)) ? "Invalid birthplace. Accepts only letters\n" : fieldInvalidMessage;
                    break;
                default:
                    throw new ArgumentException("This field does not exist");
            }

            return string.IsNullOrEmpty(fieldInvalidMessage);
        }
    }
}
