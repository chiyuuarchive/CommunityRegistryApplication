using System.Text.RegularExpressions;

namespace AuthenticatorAPI
{
    public delegate bool ValidateRequiredField(string value);
    public delegate bool ValidateStringLength(string value, int min, int max);
    public delegate bool ValidateDate(string val, out DateTime date);
    public delegate bool ValidateMatchPattern(string value, string pattern);
    public delegate bool ValidateMatchingFields(string value, string valueToCompare);

    public class MemberFieldValidators
    {
        private static ValidateRequiredField? validateRequiredField = null;
        private static ValidateStringLength? validateStringLength = null;
        private static ValidateDate? validateDate = null;
        private static ValidateMatchPattern? validateMatchPattern = null;
        private static ValidateMatchingFields? validateMatchingFields = null;

        // Singleton instances of each validators
        public static ValidateRequiredField ValidateRequiredField
        {
            get
            {
                if (validateRequiredField == null) validateRequiredField = new ValidateRequiredField(RequiredField);
                return validateRequiredField;
            }
        }
        public static ValidateStringLength ValidateStringLength
        {
            get
            {
                if (validateStringLength == null) validateStringLength= new ValidateStringLength(StringLength);
                return validateStringLength;
            }
        }
        public static ValidateDate ValidateDate
        {
            get
            {
                if (validateDate == null) validateDate= new ValidateDate(Date);
                return validateDate;
            }
        }
        public static ValidateMatchPattern ValidateMatchPattern
        {
            get
            {
                if (validateMatchPattern == null) validateMatchPattern = new ValidateMatchPattern(MatchPattern);
                return validateMatchPattern;
            }
        }
        public static ValidateMatchingFields ValidateMatchingFields
        {
            get
            {
                if (validateMatchingFields == null) validateMatchingFields = new ValidateMatchingFields(MatchingFields);
                return validateMatchingFields;
            }
        }

        private static bool RequiredField(string value) => !string.IsNullOrEmpty(value);
        private static bool StringLength(string value, int min, int max) => value.Length >= min && value.Length <= max;
        private static bool Date(string value, out DateTime date) => DateTime.TryParse(value, out date);
        private static bool MatchPattern(string value, string regexPattern)
        {
            Regex regex = new Regex(regexPattern);
            return regex.IsMatch(value);
        }
        private static bool MatchingFields(string value, string valueToCompare) => value.Equals(valueToCompare);
    }
}
