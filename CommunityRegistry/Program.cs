using CommunityRegistry;
using CommunityRegistry.Views;

// See https://aka.ms/new-console-template for more information
IView mainView = Factory.GetMainViewObject();
mainView.RunView();
Console.ReadKey();