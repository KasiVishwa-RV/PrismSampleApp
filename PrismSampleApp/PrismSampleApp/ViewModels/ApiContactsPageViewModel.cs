using PrismSampleApp.Model;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Navigation;
using PrismSampleApp.Services.Interfaces;
using System;
using Prism.Commands;
using System.Linq;
using Prism.Mvvm;

namespace PrismSampleApp.ViewModels
{
    public class ApiContactsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IRandomUserService _randomUserService;
        private List<Result> _apiContacts;
        public ICommand ClickCommand { get; set; }
        public DelegateCommand<object> ItemTappedCommand { get; set; }
        public ApiContactsPageViewModel(INavigationService navigationService, Prism.Services.IPageDialogService @object, IRandomUserService randomUserService)
        {
            ClickCommand = new Command(ClickCommandHandler);
            ItemTappedCommand = new DelegateCommand<object>(ItemTappedCommandHandler);
            _navigationService = navigationService;
            _randomUserService = randomUserService;
        }
        private async void ItemTappedCommandHandler(object data)
        {
            var result = data as Result;
            var Data = new NavigationParameters();
            var list = ApiContacts.Where(x => x==result).ToList();
            Data.Add("TappedData", list);
            await _navigationService.NavigateAsync("ViewContactListPage",Data);
        }

        private void ClickCommandHandler()
        {
            GetContacts();
        }
        public List<Result> ApiContacts
        {
            get
            {
                return _apiContacts;
            }
            set
            {
                SetProperty(ref _apiContacts, value);
            }
        }
        public async void GetContacts()
        {
            ApiContacts = await _randomUserService.GetContactsAsync();   
        }
    }
}