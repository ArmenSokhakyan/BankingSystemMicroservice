using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotificationServiceSystem.Core.Entities;
using NotificationServiceSystem.Core.Interfaces.Services;
using NotificationServiceSystem.Presentation.API.DTOs;

namespace NotificationServiceSystem.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationDTO>>> GetNotificatons()
        {
            var notifications = await _notificationService.GetNotificationsAsync();
            var notificationsDTO = _mapper.Map<IEnumerable<NotificationDTO>>(notifications);
            return Ok(notificationsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationDTO>> GetNotification(int id)
        {
            var notification = await _notificationService.GetNotificationAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            var notificationDTO = _mapper.Map<NotificationDTO>(notification);
            return Ok(notificationDTO);
        }

        [HttpGet("receiver/{receiver}")]
        public async Task<ActionResult<IEnumerable<NotificationDTO>>> GetNotificationsByReceiver(string receiver)
        {
            var notifications = await _notificationService.GetNotificationsByReceiverAsync(receiver);
            var notificationsDTO = _mapper.Map<IEnumerable<NotificationDTO>>(notifications);

            return Ok(notificationsDTO);
        }

        [HttpPost]
        public async Task<ActionResult<NotificationDTO>> AddNotification([FromBody] NotificationDTO notificationDTO)
        {
            Notification notification = _mapper.Map<Notification>(notificationDTO);
            
            await _notificationService.AddNotificationAsync(notification);

            return CreatedAtAction(nameof(GetNotification), new { Id = notification.Id}, notification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification([FromBody] NotificationDTO notificationDTO, int id)
        {
            if(notificationDTO.Id != id)
            {
                return BadRequest("Ids are different");
            }

            Notification notification = _mapper.Map<Notification>(notificationDTO);
            await _notificationService.UpdateNotificationAsync(notification);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            await _notificationService.DeleteNotificationAsync(id);
            return NoContent();
        }

    }
}
