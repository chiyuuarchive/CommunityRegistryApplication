using CommunityRegistry.Models;

namespace CommunityRegistry.Data
{
    internal class LoginMember : ILogin
    {
        public Member Login(string email, string password)
        {
            Member member = null;

            using (var dbContext = new MemberDatabaseContext())
            {
                member = dbContext.Members.FirstOrDefault(member => member.Email.ToLower().Trim() == email.ToLower().Trim() && member.Password.ToLower().Trim() == password.ToLower().Trim());
            }

            return member;
        }
    }
}
