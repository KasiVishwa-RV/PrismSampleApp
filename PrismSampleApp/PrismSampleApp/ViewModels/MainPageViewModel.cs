using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using PrismSampleApp.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PrismSampleApp.Resx;
using System.Globalization;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Essentials;

namespace PrismSampleApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase , IPageLifecycleAware
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        public ICommand GoToApiContactsPageCommand { get; set; }
        public ICommand GoToHomePageCommand { get; set; }
        public ICommand ChangeLanguageCommand { get; set; }
        public ICommand TurnOnFlashLightCommand { get; set; }
        public ICommand TurnOffFlashLightCommand { get; set; }
        private string _title;
        private MyLanguage _selectedLanguage;
        private ObservableCollection<MyLanguage> _supportedLanguage;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }
        public ObservableCollection<MyLanguage> SupportedLanguage
        {
            get { return _supportedLanguage; }
            set { SetProperty(ref _supportedLanguage, value); }
        }
        public MyLanguage SelectedLanguage
        {
            get { return _selectedLanguage; }
            set { SetProperty(ref _selectedLanguage, value); }
        }
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            Title = "Main Page";
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            GoToApiContactsPageCommand = new DelegateCommand(GoToApiContactsPageCommandHandler);
            GoToHomePageCommand = new DelegateCommand(GoToHomePageCommandHandler);   
            ChangeLanguageCommand = new Command(PerformOperation);
            TurnOnFlashLightCommand = new Command(TurnOnFlashLightCommandHandler);
            TurnOffFlashLightCommand = new Command(TurnOffFlashLightCommandHandler);
            SupportedLanguage = new ObservableCollection<MyLanguage>()
            {
                new MyLanguage{Name=AppResource.English,CI="en"},
                new MyLanguage{Name=AppResource.French,CI="fr"},
                new MyLanguage{Name=AppResource.Tamil,CI="ta"}
            };
            SelectedLanguage = SupportedLanguage.FirstOrDefault(x => x.CI == LocalizationResourceManager.Current.CurrentCulture.TwoLetterISOLanguageName);
        }
        private void PerformOperation(object obj)
        {
            LocalizationResourceManager.Current.SetCulture(CultureInfo.GetCultureInfo(SelectedLanguage.CI));
        }
        private async void GoToApiContactsPageCommandHandler()
        {
            await _navigationService.NavigateAsync("ApiContactsPage");
        }
        private async void GoToHomePageCommandHandler()
        {
            await _navigationService.NavigateAsync("HomePage");
        }
        public Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return _pageDialogService.DisplayAlertAsync(Title, "Navigate", "Yes", "No");
        }
        public void OnAppearing()
        {
            //await _pageDialogService.DisplayAlertAsync("MainPage","We are appearing","ok");
            Vibration.Vibrate(); 
        }
        public async void OnDisappearing()
        {
           //await _pageDialogService.DisplayAlertAsync("MainPage", "We are disappearing", "ok");
            Vibration.Vibrate(); 
        }
        public async void TurnOnFlashLightCommandHandler()
        {
            await Flashlight.TurnOnAsync();
        }
        public async void TurnOffFlashLightCommandHandler()
        {
            await Flashlight.TurnOffAsync();
        }
    }
}