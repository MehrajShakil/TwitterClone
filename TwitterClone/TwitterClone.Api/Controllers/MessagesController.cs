using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{

    // api/messages
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private readonly IMessageService _messageService;

        public MessagesController(
            IMessageService messageService)
        {
            _messageService = messageService;
        }


        // GET /api/messages?senderId={senderId}&receiverId={receiverId}
        [HttpGet]
        [ProducesResponseType(typeof(List<MessageDto>), StatusCodes.Status200OK)]
        public IActionResult GetMessages([FromQuery] Guid? senderId, [FromQuery] Guid? receiverId)
        {
            return Ok(_messageService.GetMessages(senderId, receiverId));
        }

        // GET /api/messages/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MessageDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMessageById([FromRoute] Guid id)
        {
            var message = _messageService.GetMessageById(id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // GET /api/messages/conversation?userId={userId}&otherUserId={otherUserId}
        [HttpGet("conversation")]
        [ProducesResponseType(typeof(List<MessageDto>), StatusCodes.Status200OK)]
        public IActionResult GetConversation([FromQuery] Guid userId, [FromQuery] Guid otherUserId)
        {
            return Ok(_messageService.GetConversation(userId, otherUserId));
        }

        // POST /api/messages
        [HttpPost]
        [ProducesResponseType(typeof(MessageDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SendMessage([FromBody] CreateMessageDto createMessageDto)
        {
            var sentMessage = _messageService.SendMessage(createMessageDto);

            if (sentMessage == null)
            {
                // Content is already validated by [ApiController], so what is left is an unknown user or messaging yourself.
                return BadRequest("Both users must exist, and a user cannot message themselves.");
            }

            return CreatedAtAction(nameof(GetMessageById), new { id = sentMessage.Id }, sentMessage);
        }

        // PUT /api/messages/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MessageDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateMessage([FromRoute] Guid id, [FromBody] UpdateMessageDto updateMessageDto)
        {
            var message = _messageService.UpdateMessage(id, updateMessageDto);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // PATCH /api/messages/{id}/read
        [HttpPatch("{id}/read")]
        [ProducesResponseType(typeof(MessageDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult MarkMessageAsRead([FromRoute] Guid id)
        {
            var message = _messageService.MarkMessageAsRead(id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // DELETE /api/messages/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteMessage([FromRoute] Guid id)
        {
            var isDeleted = _messageService.DeleteMessage(id);

            if (isDeleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
