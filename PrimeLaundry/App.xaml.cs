using System;
using PrimeLaundry.ViewModels;
using PrimeLaundry.Views;
using Prism;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrimeLaundry
{
    public partial class App : PrismApplication
    {

        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override async void OnInitialized()
        {
            InitializeComponent();

            //Uncomment this list to Test Prism Tabbed Page 
            //  NavigationService.NavigateAsync(new System.Uri("/NavigationPage/CustomTabbedPage?selectedTab=Test2Page", System.UriKind.Absolute));
            var result = await NavigationService.NavigateAsync("NavigationPage/LoginPage");
            if (!result.Success)
            {
                SetMainPageFromException(result.Exception);
            }

            //Uncomment this list to Test Prism Master DetailPage 
            //  NavigationService.NavigateAsync(new System.Uri("/CustomMasterDetailPage/NavigationPage/Test2Page", System.UriKind.Absolute));

            //Uncomment this list to Test Prism general concepts as Custom NavigationPage/Modules/DelegateCommands/Services 
            //NavigationService.NavigateAsync(new System.Uri("http://www.MyTestApp/CustomNavigationPage/LoginPage", System.UriKind.Absolute));

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            // all the Screen and plateform specific interface or serveice must be mentioned here
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();


        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //Type authenticationModuleType = typeof(AuthenticationModule.AuthenticationModule);
            //moduleCatalog.AddModule(
            // new ModuleInfo(authenticationModuleType)
            // {
            //     ModuleName = authenticationModuleType.Name,
            //     InitializationMode = InitializationMode.OnDemand
            // });
        }

        private void SetMainPageFromException(Exception ex)
        {
            var layout = new StackLayout
            {
                Padding = new Thickness(40)
            };
            layout.Children.Add(new Label
            {
                Text = ex?.GetType()?.Name ?? "Unknown Error encountered",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            });

            layout.Children.Add(new ScrollView
            {
                Content = new Label
                {
                    Text = $"{ex}",
                    LineBreakMode = LineBreakMode.WordWrap
                }
            });

            MainPage = new ContentPage
            {
                Content = layout
            };
        }


    }
}