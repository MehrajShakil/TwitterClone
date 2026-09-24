using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{

    // api/messages
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        public MessagesController() { }


        // GET /api/messages?senderId={senderId}&receiverId={receiverId}
        [HttpGet]
        public IActionResult GetMessages([FromQuery] Guid? senderId, [FromQuery] Guid? receiverId)
        {
            return Ok(new List<object>
            {
                new
                {
                    MessageId = Guid.NewGuid(),
                    SenderId = senderId ?? Guid.NewGuid(),
                    ReceiverId = receiverId ?? Guid.NewGuid(),
                    Content = "Hey, how are you?",
                    SentAt = DateTime.UtcNow.AddMinutes(-15),
                    IsRead = true,
                },
                new
                {
                    MessageId = Guid.NewGuid(),
                    SenderId = senderId ?? Guid.NewGuid(),
                    ReceiverId = receiverId ?? Guid.NewGuid(),
                    Content = "Did you see my latest tweet?",
                    SentAt = DateTime.UtcNow.AddMinutes(-5),
                    IsRead = false,
                },
            });
        }

        // GET /api/messages/{id}
        [HttpGet("{id}")]
        public IActionResult GetMessageById([FromRoute] Guid id)
        {
            return Ok(new
            {
                MessageId = id,
                SenderId = Guid.NewGuid(),
                ReceiverId = Guid.NewGuid(),
                Content = "message" + id.ToString(),
                SentAt = DateTime.UtcNow,
                IsRead = false,
            });
        }

        // GET /api/messages/conversation?userId={userId}&otherUserId={otherUserId}
        [HttpGet("conversation")]
        public IActionResult GetConversation([FromQuery] Guid userId, [FromQuery] Guid otherUserId)
        {
            return Ok(new List<object>
            {
                new
                {
                    MessageId = Guid.NewGuid(),
                    SenderId = userId,
                    ReceiverId = otherUserId,
                    Content = "Hi!",
                    SentAt = DateTime.UtcNow.AddMinutes(-10),
                    IsRead = true,
                },
                new
                {
                    MessageId = Guid.NewGuid(),
                    SenderId = otherUserId,
                    ReceiverId = userId,
                    Content = "Hello back!",
                    SentAt = DateTime.UtcNow.AddMinutes(-8),
                    IsRead = false,
                },
            });
        }

        // POST /api/messages
        [HttpPost]
        public IActionResult SendMessage()
        {
            return Ok(new
            {
                MessageId = Guid.NewGuid(),
                SenderId = Guid.NewGuid(),
                ReceiverId = Guid.NewGuid(),
                Content = "New message content.",
                SentAt = DateTime.UtcNow,
                IsRead = false,
            });
        }

        // PUT /api/messages/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMessage([FromRoute] Guid id)
        {
            return Ok(new
            {
                MessageId = id,
                SenderId = Guid.NewGuid(),
                ReceiverId = Guid.NewGuid(),
                Content = "updatedmessage" + id.ToString(),
                ModifiedAt = DateTime.UtcNow,
            });
        }

        // PATCH /api/messages/{id}/read
        [HttpPatch("{id}/read")]
        public IActionResult MarkMessageAsRead([FromRoute] Guid id)
        {
            return Ok(new
            {
                MessageId = id,
                IsRead = true,
            });
        }

        // DELETE /api/messages/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage([FromRoute] Guid id)
        {
            return Ok(new
            {
                MessageId = id,
                Message = "Message deleted successfully.",
            });
        }
    }
}
