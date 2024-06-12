namespace CommunityRegistry.Authentication
{
    internal class FieldTypes
    {
        public enum UserRegistrationField
        {
            FirstName,
            LastName,
            Email,
            Password,
            ComparePassword,
            Occupation,
            DateOfBirth,
            Birthplace
        }

        public enum UserLoginField
        {
            Email,
            Password
        }
    }
}
