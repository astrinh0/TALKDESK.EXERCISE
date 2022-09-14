using JNGV.TALKDESK.API.Repository;
using JNGV.TALKDESK.API.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace JNGV.TALKDESK.TESTS
{
    public class ApiTest
    {
        private Mock<IConfiguration> _mockConfiguration = new Mock<IConfiguration>();
        private Mock<IHttpClientFactory> _mockClient = new Mock<IHttpClientFactory>();

        [Fact]
        public void CheckIfNotNull()
        {
            //ARRANGE
            var httpService = new HttpService(_mockClient.Object, _mockConfiguration.Object);
            var test = "+1382355";

            //ACT
            var result = httpService.RequestApi(test);

            //ASSERT
            Assert.NotNull(result);
        }

        
    }
}