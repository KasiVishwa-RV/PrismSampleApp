using Prism.Navigation;
using PrismSampleApp.AppConstants;
using PrismSampleApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSampleApp.ViewModels
{
    public class MessagingCenterPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessagingCenter _messagingCenter;
        public ICommand SendMessageCommand { get; set; }
        public MessagingCenterPageViewModel(INavigationService NavigationService, IMessagingCenter messagingCenter)
        {
            _navigationService = NavigationService;
            _messagingCenter = messagingCenter;
            SendMessageCommand = new Command(SendMessageCommandHandler);
        }
        public void SendMessageCommandHandler()
        {
            _messagingCenter.Send<MessagingCenterPageViewModel, DateTime>(this, Constants.Tick, DateTime.Now);
        }
    }
}