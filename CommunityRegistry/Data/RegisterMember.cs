using CommunityRegistry.Models;
using CommunityRegistry.Authentication;

namespace CommunityRegistry.Data
{
    internal class RegisterMember : IRegister
    {
        public bool EmailExists(string email)
        {
            bool emailExists = false;

            using (var dbContext = new MemberDatabaseContext())
            {
                if (dbContext.Members == null) return false;
                emailExists = dbContext.Members.Any(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
            }

            return emailExists;
        }

        public bool Register(string[] fields)
        {
            using (var dbContext = new MemberDatabaseContext())
            {
                Member member = new Member
                {
                    FirstName = fields[(int)FieldTypes.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldTypes.UserRegistrationField.LastName],
                    Email = fields[(int)FieldTypes.UserRegistrationField.Email],
                    Password = fields[(int)FieldTypes.UserRegistrationField.Password],
                    Occupation = fields[(int)FieldTypes.UserRegistrationField.Occupation],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldTypes.UserRegistrationField.DateOfBirth]),
                    Birthplace = fields[(int)FieldTypes.UserRegistrationField.Birthplace]
                };

                dbContext.Members?.Add(member);
                dbContext.SaveChanges();
            }

            return true;
        }
    }
}
