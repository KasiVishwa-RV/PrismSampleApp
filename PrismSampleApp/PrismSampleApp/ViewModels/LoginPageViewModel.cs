using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Threading.Tasks;
using Prism.Services;
using PrismSampleApp.Views;
using PrismSampleApp.Services.Interfaces;
using PrismSampleApp.Repository.Interfaces;
using PrismSampleApp.Model;
using PrismSampleApp.Resx;
using Prism.AppModel;
using Xamarin.Essentials;

namespace PrismSampleApp.ViewModels
{
    public class LoginPageViewModel :ViewModelBase, IPageLifecycleAware
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private readonly IGenericRepository<EmployeeModel> _genericRepository;
        private string _username;
        private string _password;
        private string _batteryDetails;
        public ICommand LoginCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        public LoginPageViewModel(INavigationService NavigationService, IPageDialogService pageDialogService, IGenericRepository<EmployeeModel> genericRepository)
        {
            _navigationService = NavigationService;
            _genericRepository = genericRepository;
            //_genericRepository.Insert(new EmployeeModel { Email = "john", Password = "54321" });
            _pageDialogService = pageDialogService;
            LoginCommand = new Command(LoginCommandHandler);
            SignUpCommand = new Command(SignUpCommandHandler);
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                SetProperty(ref _username, value);
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
               SetProperty(ref _password , value);
                
            }
        }
        public string BatteryDetails
        {
            get
            {
                return _batteryDetails;
            }
            set
            {
               SetProperty(ref _batteryDetails, value);
                
            }
        }
        public async void LoginCommandHandler()
        {
            var result = await _genericRepository.Get();
            var user = result.Where(x => x.UserName == Username && x.Password == Password).FirstOrDefault();
            if (user!=null)
            {
                await _navigationService.NavigateAsync("MainPage");
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync(AppResource.LoginPage,AppResource.WrongCredentials, "Retry");
            }
        }
        public async void SignUpCommandHandler()
        {
            await _navigationService.NavigateAsync("SignUpPage");
        }

        void IPageLifecycleAware.OnAppearing()
        {
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            Accelerometer.Start(SensorSpeed.Game);
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        }

        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
                _batteryDetails = $"Reading: Level: {Battery.ChargeLevel}, State: {Battery.State}, Source: {Battery.PowerSource}";         
        }
        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                LoginCommandHandler();
            });
        }

        public void OnDisappearing()
        {
            Accelerometer.ShakeDetected -= Accelerometer_ShakeDetected;
            Accelerometer.Stop();
            Battery.BatteryInfoChanged -= Battery_BatteryInfoChanged;
        }
    }
}