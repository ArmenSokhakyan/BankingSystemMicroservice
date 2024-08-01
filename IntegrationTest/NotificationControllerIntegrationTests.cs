using IntegrationTest.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;

namespace IntegrationTest
{
    public class NotificationControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public NotificationControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task CreateNotification_ReturnsCreatedAtActionResult()
        {
            //Arrange
            var notificationDTO = new NotificationDTO
            {
                Receiver = "asokhakyan",
                Title = "Armen",
                Content = "Content"
            };

            var content = new StringContent(JsonConvert.SerializeObject(notificationDTO));

            //Act
            var response = await _httpClient.PostAsync("/api/nitification", content);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var createdNotification = JsonConvert.DeserializeObject<NotificationDTO>(responseString);

            Assert.NotNull(createdNotification);
            Assert.Equal(notificationDTO.Receiver, createdNotification.Receiver);
            Assert.Equal(notificationDTO.Title, createdNotification.Title);
            Assert.Equal(notificationDTO.Content, createdNotification.Content);
            Assert.True(notificationDTO.Id > 0);
        }
    }
}