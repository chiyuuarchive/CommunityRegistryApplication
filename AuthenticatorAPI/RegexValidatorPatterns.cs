namespace AuthenticatorAPI
{
    public static class RegexValidatorPatterns
    {
        public const string EMAIL = @"^[\w]+@[A-Za-z0-9]+\.[A-Za-z]{2,3}$";
        // Password must have 1 uppercase, 1 lowercase letter and 1 digit
        public const string PASSWORD = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
        // Occupation accepts only letters
        public const string OCCUPATION = @"^(?=.*[a-zA-Z])[a-zA-Z]{2,}$";
        // Hometown accepts only letters
        public const string BIRTHPLACE = @"^(?=.*[a-zA-Z])[a-zA-Z]{2,}$";
    }
}
