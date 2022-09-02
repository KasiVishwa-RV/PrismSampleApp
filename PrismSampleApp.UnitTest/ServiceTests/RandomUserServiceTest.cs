using AutoFixture;
using Flurl.Http.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using Prism.Services;
using PrismSampleApp.Services;
using PrismSampleApp.Services.Interfaces;
using PrismSampleApp.ViewModels;
using PrismSampleApp.Views;
using System.Threading.Tasks;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PrismSampleApp.UnitTest.ServiceTest
{
    public class RandomUserServiceTest
    {
        private readonly RandomUserService _randomUserService;
        public RandomUserServiceTest()
        {
            _randomUserService = new RandomUserService();
        }
        [Fact]
        public async void GetData()
        {
            using (var httpTest = new HttpTest())
            {
                //Arrange
                httpTest.RespondWith("OK", 200);
                httpTest.ForCallsTo("https://randomuser.me/api/?results=50").AllowRealHttp();
                //Act
                var result = await _randomUserService.GetContactsAsync();
                //Assert
                httpTest.RespondWithJson("https://randomuser.me/api/?results=50");
                Assert.AreEqual(50, result.Count);
                Assert.AreEqual("System.Collections.Generic.List`1[PrismSampleApp.Model.Result]", result.GetType().ToString());
            }
        }
    }
}