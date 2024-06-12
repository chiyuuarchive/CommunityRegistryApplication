namespace CommunityRegistry.Data
{
    internal interface IRegister
    {
        bool Register(string[] fields);
        bool EmailExists(string email);
    }
}
