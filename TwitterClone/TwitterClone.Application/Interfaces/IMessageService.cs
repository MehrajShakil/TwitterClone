using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IMessageService
    {
        MessageDto? SendMessage(CreateMessageDto createMessageDto);
        MessageDto? GetMessageById(Guid id);
        List<MessageDto> GetMessages(Guid? senderId, Guid? receiverId);
        List<MessageDto> GetConversation(Guid userId, Guid otherUserId);
        MessageDto? UpdateMessage(Guid id, UpdateMessageDto updateMessageDto);
        MessageDto? MarkMessageAsRead(Guid id);
        bool DeleteMessage(Guid id);
    }
}
