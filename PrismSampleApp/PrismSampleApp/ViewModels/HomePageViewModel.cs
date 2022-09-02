using Prism.Navigation;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSampleApp.ViewModels
{
    public class HomePageViewModel:ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessagingCenter _messagingCenter;

        private string _messages;
        public ICommand GoToMessagingCenterPageCommand { get; set; }
        public ICommand SubscribeCommand { get; set; }
        public HomePageViewModel(INavigationService NavigationService, IMessagingCenter messagingCenter)
        {
            _navigationService = NavigationService;
            _messagingCenter = messagingCenter;
            SubscribeCommand = new Command(SubscribeCommandHandler);
            GoToMessagingCenterPageCommand = new Command(GoToMessagingCenterPageCommandHandler);
        }
        public string Messages
        { 
            get 
            { 
                return _messages; 
            }
            set
            {
                SetProperty(ref _messages, value);
            }
        } 
        public void SubscribeCommandHandler()
        {
            _messagingCenter.Subscribe<MessagingCenterPageViewModel, DateTime>(this, AppConstants.Constants.Tick, (sender,DateTime) =>
             {
                 Messages = $"Logged in @ {DateTime.Now}";
             });
        }
        private async void GoToMessagingCenterPageCommandHandler()
        {
          await _navigationService.NavigateAsync("MessagingCenterPage");
        }
    }
}
