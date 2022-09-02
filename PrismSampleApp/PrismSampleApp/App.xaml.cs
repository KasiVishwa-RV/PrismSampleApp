
using Prism;
using Prism.Ioc;
using PrismSampleApp.ApplicationCommand;
using PrismSampleApp.Services;
using PrismSampleApp.Services.Interfaces;
using PrismSampleApp.ViewModels;
using PrismSampleApp.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using PrismSampleApp.Resx;
using Xamarin.CommunityToolkit.Helpers;
using Plugin.FirebasePushNotification;
using System;
using PrismSampleApp.Repository.Interfaces;
using PrismSampleApp.Repository;

namespace PrismSampleApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            LocalizationResourceManager.Current.Init(AppResource.ResourceManager);
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
            CrossFirebasePushNotification.Current.OnTokenRefresh += firebasePushNotificationTokenEventHandler;
        }

        private void firebasePushNotificationTokenEventHandler(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Token: { e.Token}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        { 
            containerRegistry.Register<IRandomUserService,RandomUserService>();
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
            //containerRegistry.RegisterSingleton<ILogger>();
            containerRegistry.RegisterSingleton<ILogManager>();
            containerRegistry.RegisterSingleton<IMessagingCenter,MessagingCenter>();
            containerRegistry.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));



            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewContactListPage, ViewContactListPageViewModel>();
            containerRegistry.RegisterForNavigation<ApiContactsPage, ApiContactsPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<MessagingCenterPage, MessagingCenterPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
        }
        protected override void OnStart()
        {
            base.OnStart();
        }
        protected override void OnSleep()
        {
            base.OnSleep();
        }
        protected override async void OnResume()
        {
            base.OnResume();
        }

    }
}
