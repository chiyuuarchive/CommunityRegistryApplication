using CommunityRegistry.Data;
using CommunityRegistry.Views;
using CommunityRegistry.Authentication;

namespace CommunityRegistry
{
    public static class Factory
    {

        public static IView GetMainViewObject()
        {

            ILogin login = new LoginMember();
            IRegister register = new RegisterMember();
            IFieldValidator registrationValidator = new MemberRegistrationValidator(register);
            registrationValidator.InitializeValidatorDelegates();
            IFieldValidator loginValidator = new MemberLoginValidator();
            loginValidator.InitializeValidatorDelegates();

            IView registerView = new RegistrationView(register, registrationValidator);
            IView loginView = new LoginView(login, loginValidator);
            IView mainView = new MainView(registerView, loginView);

            return mainView;
        }

    }
}
