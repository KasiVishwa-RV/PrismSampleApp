using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using Prism.Services;
using PrismSampleApp.Repository.Interfaces;
using PrismSampleApp.ViewModels;
using PrismSampleApp.Views;
using System.Threading.Tasks;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PrismSampleApp.UnitTest
{
    public class LoginPageViewModelTest
    {
        private readonly Mock<INavigationService> _navigationService;
        private readonly Mock<IPageDialogService> _pageDialogService;
        private readonly LoginPageViewModel _loginPageviewModel;
        private readonly Fixture _fixture = new Fixture();
        public LoginPageViewModelTest()
        {
            _navigationService = new Mock<INavigationService>();
            _pageDialogService = new Mock<IPageDialogService>();
           // viewModel = new LoginPageViewModel(_navigationService.Object, _pageDialogService.Object);
        }
    [Fact]
        public void Login_With_Valid_Credentials()
        {
            //Arrange
            var username = _fixture.Create<string>();
            var password = _fixture.Create<string>();
            //Act
            _navigationService.Setup(x => x.NavigateAsync("MainPage")).ReturnsAsync(_fixture.Create<NavigationResult>());
            _pageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "", "Retry"));
            _loginPageviewModel.Username = "admin";
            _loginPageviewModel.Password = "123";
            _loginPageviewModel.LoginCommand.Execute(new());
            //Assert
            _navigationService.Verify(x => x.NavigateAsync("MainPage"));  
        }

        [Fact]
        public void Login_With_InValid_Credentials()
        {
            //Arrange
            var username = _fixture.Create<string>();
            var password = _fixture.Create<string>();
            //Act
            _pageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            _loginPageviewModel.Username = username ;
            _loginPageviewModel.Password = password;
            _loginPageviewModel.LoginCommand.Execute(new());
            //Assert
            _pageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
        [Fact]
        public void Login_With_Valid_UserName_Invalid_Password()
        {
            var password = _fixture.Create<string>();
            //Act
            _pageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            _loginPageviewModel.Username = null;
            _loginPageviewModel.Password = null;
            _loginPageviewModel.LoginCommand.Execute(new());
            //Assert
            _pageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
        [Fact]
        public void Login_With_InValid_UserName_Valid_Password()
        {
            var username = _fixture.Create<string>();
            //Act
            _pageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            //Arrange
            _loginPageviewModel.Username = username;
            _loginPageviewModel.Password = "123";
            _loginPageviewModel.LoginCommand.Execute(new());
            //Assert
            _pageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
        [Fact]
        public void Login_With_Blank_UserName_Blank_Password()
        {
            //Arrange
            
            //Act
            _pageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            _loginPageviewModel.Username = null;
            _loginPageviewModel.Password = null;
            _loginPageviewModel.LoginCommand.Execute(new());
            //Assert
            _pageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
        [Fact]
        public void Login_With_Valid_UserName_Blank_Password()
        {
            //Arrange
            //Act
            _pageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            _loginPageviewModel.Username = "admin";
            _loginPageviewModel.Password = null;
            _loginPageviewModel.LoginCommand.Execute(new());
            //Assert
            _pageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));

        }
        [Fact]
        public void Login_With_InValid_UserName_Blank_Password()
        {
            var username = _fixture.Create<string>();
            //Arrange
            _pageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            _loginPageviewModel.Username = username;
            _loginPageviewModel.Password = null;
            //Act
            _loginPageviewModel.LoginCommand.Execute(new());
            //Assert
            _pageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
        [Fact]
        public void Login_With_Blank_UserName_Valid_Password()
        {
            //Arrange
            //Act
            _pageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            _loginPageviewModel.Username = null;
            _loginPageviewModel.Password = "123";
            _loginPageviewModel.LoginCommand.Execute(new());
            //Assert
            _pageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
        [Fact]
        public void Login_With_Blank_UserName_InValid_Password()
        {
            var password = _fixture.Create<string>();
            //Arrange
            //Act
            _pageDialogService.Setup(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
            _loginPageviewModel.Username = null;
            _loginPageviewModel.Password = password;
            _loginPageviewModel.LoginCommand.Execute(new());
            //Assert
            _pageDialogService.Verify(x => x.DisplayAlertAsync("LoginPage", "Wrong Credentials", "Retry"));
        }
    }
}