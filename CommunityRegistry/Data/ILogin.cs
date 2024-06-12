using CommunityRegistry.Models;

namespace CommunityRegistry.Data
{
    internal interface ILogin
    {
        Member Login(string email, string password);
    }
}
