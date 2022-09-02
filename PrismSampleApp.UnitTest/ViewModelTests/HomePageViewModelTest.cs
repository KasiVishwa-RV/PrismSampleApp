using AutoFixture;
using Moq;
using Prism.Navigation;
using PrismSampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xunit;

namespace PrismSampleApp.UnitTest.ViewModelTests
{
    public class HomePageViewModelTest
    {
        private readonly Mock<INavigationService> _navigationService;
        private readonly Mock<IMessagingCenter> _messagingCenter;
        private readonly HomePageViewModel homePageViewModel;
        private readonly Fixture _fixture = new Fixture();
        public HomePageViewModelTest()
        {
            _navigationService = new Mock<INavigationService>();
            _messagingCenter = new Mock<IMessagingCenter>();
            homePageViewModel = new HomePageViewModel(_navigationService.Object,_messagingCenter.Object);
        }
        [Fact]
        public void MessageSubscription()
        {
            //Arrange
            //var Messages = false;
            ////homePageViewModel.SubscribeCommand.Execute(new());
            //_messagingCenter.Object.Subscribe<MessagingCenterPageViewModel, DateTime>(this, "Hi", (sender, DateTime) =>
            //  {
            //      Messages = true;
            //  });
            //Act
            //Assert
            //Assert.True(Messages);
            //_messagingCenter.Verify(Subscribe<MessagingCenterPageViewModel, DateTime>(this, "Hi", (sender, DateTime) =>
            //{
            //    Messages = true;
            //}));
        }
    }
}
