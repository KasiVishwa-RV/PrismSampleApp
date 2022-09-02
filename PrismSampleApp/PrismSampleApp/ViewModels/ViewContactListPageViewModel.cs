using Prism.Navigation;
using PrismSampleApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using PrismSampleApp.Services.Interfaces;

namespace PrismSampleApp.ViewModels
{
    public class ViewContactListPageViewModel : ViewModelBase , INavigatedAware
    {
        private List<Result> _content;
        private ObservableCollection<Result> _seperateDetails;
        private readonly IRandomUserService _randomUserService;
        public ICommand CallCommand { get; set; }
        public ICommand SmsCommand { get; set; }
        public ICommand EmailCommand { get; set; }
        public ViewContactListPageViewModel(IRandomUserService randomUserService)
        {
            _randomUserService = randomUserService;
            CallCommand = new Command(CallCommandHandler);
            SmsCommand = new Command(SmsCommandHandler);
            EmailCommand = new Command(EmailCommandHandler);
        }

        public async void EmailCommandHandler()
        {
            await Email.ComposeAsync();
        }
        public async void SmsCommandHandler()
        {
            await Sms.ComposeAsync();
        }
        public void CallCommandHandler()
        {
            PhoneDialer.Open("0");
        }

        public List<Result> Content
        {
            get
            {
                return _content;
            }
            set
            {
                SetProperty(ref _content, value);
            }
        }
        public ObservableCollection<Result> SeperateDetails
        {
            get
            {
                return _seperateDetails;
            }
            set
            {
                SetProperty(ref _seperateDetails, value);
            }
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }
        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Content = parameters.GetValue<List<Result>>("TappedData");
            ObservableCollection<Result> DetailedCollection = new ObservableCollection<Result>(Content);

            SeperateDetails = DetailedCollection;
        }
    }
}
