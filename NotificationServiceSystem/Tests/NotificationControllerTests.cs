using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NotificationServiceSystem.Core.Entities;
using NotificationServiceSystem.Core.Interfaces.Services;
using NotificationServiceSystem.Presentation.API.Controllers;
using NotificationServiceSystem.Presentation.API.DTOs;
using Xunit;

namespace NotificationServiceSystem.Tests
{
    public class NotificationControllerTests
    {
        private readonly Mock<INotificationService> _mockNotificationService;
        private readonly NotificationController _controller;
        private readonly IMapper _mapper;

        public NotificationControllerTests()
        {
            _mockNotificationService = new Mock<INotificationService>();

            //Set up AutoMapper configuration and create IMapper instance
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Presentation.API.Mappers.AutoMapper>(); // Assuming AutoMapperProfile is your mapping profile
            });
            _mapper = config.CreateMapper();

            _controller = new NotificationController(_mockNotificationService.Object, _mapper);
        }

        [Fact]
        public async Task AddNotification()
        {
            var notification = new Notification { Receiver = "armen", Title = "Test", Content = "Test content" };
            var notificationDTO = new NotificationDTO { Receiver = "armen", Title = "Test", Content = "Test content" };

            _mockNotificationService.Setup(service => service.AddNotificationAsync(notification))
                    .Returns(Task.FromResult(notification));

            // Act
            var result = await _controller.AddNotification(notificationDTO);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(_controller.GetNotification), createdAtActionResult.ActionName);
            Assert.Equal(201, createdAtActionResult.StatusCode);
        }
    }
}
