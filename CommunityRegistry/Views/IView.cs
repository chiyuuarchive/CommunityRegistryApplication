using CommunityRegistry.Authentication;

namespace CommunityRegistry.Views
{
    public interface IView
    {
        void RunView();
        IFieldValidator FieldValidator { get; }
    }
}
