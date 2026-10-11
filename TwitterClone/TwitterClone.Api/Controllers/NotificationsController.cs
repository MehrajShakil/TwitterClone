using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{

    // api/notifications
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {

        private readonly INotificationService _notificationService;

        public NotificationsController(
            INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        // GET /api/notifications?userId={userId}&type={type}&isRead={isRead}
        [HttpGet]
        [ProducesResponseType(typeof(List<NotificationDto>), StatusCodes.Status200OK)]
        public IActionResult GetNotifications([FromQuery] Guid? userId, [FromQuery] string? type, [FromQuery] bool? isRead)
        {
            return Ok(_notificationService.GetNotifications(userId, type, isRead));
        }

        // GET /api/notifications/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NotificationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetNotificationById([FromRoute] Guid id)
        {
            var notification = _notificationService.GetNotificationById(id);

            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }

        // POST /api/notifications
        [HttpPost]
        [ProducesResponseType(typeof(NotificationDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateNotification([FromBody] CreateNotificationDto createNotificationDto)
        {
            var createdNotification = _notificationService.CreateNotification(createNotificationDto);

            if (createdNotification == null)
            {
                // The type is already validated by [ApiController], so the only failure left is an unknown user.
                return BadRequest("The user, or the user who triggered the notification, does not exist.");
            }

            return CreatedAtAction(nameof(GetNotificationById), new { id = createdNotification.Id }, createdNotification);
        }

        // PATCH /api/notifications/{id}/read
        [HttpPatch("{id}/read")]
        [ProducesResponseType(typeof(NotificationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult MarkNotificationAsRead([FromRoute] Guid id)
        {
            var notification = _notificationService.MarkNotificationAsRead(id);

            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }

        // PATCH /api/notifications/read-all?userId={userId}
        [HttpPatch("read-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult MarkAllNotificationsAsRead([FromQuery] Guid userId)
        {
            var updatedCount = _notificationService.MarkAllNotificationsAsRead(userId);

            return Ok(new { UserId = userId, UpdatedCount = updatedCount });
        }

        // DELETE /api/notifications/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteNotification([FromRoute] Guid id)
        {
            var isDeleted = _notificationService.DeleteNotification(id);

            if (isDeleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
