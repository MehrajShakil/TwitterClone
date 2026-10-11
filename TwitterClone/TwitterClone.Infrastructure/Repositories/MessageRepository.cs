using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {

        private readonly List<Message> _messages = new List<Message>();

        public Message AddMessage(Message message)
        {
            _messages.Add(message);

            return message;
        }

        public Message UpdateMessage(Message message)
        {
            _messages.RemoveAll(m => m.Id == message.Id);
            _messages.Add(message);
            return message;
        }

        public bool DeleteMessage(Message message)
        {
            return _messages.Remove(message);
        }

        // Removes the messages the user sent as well as the ones they received.
        public int DeleteMessagesByUserId(Guid userId)
        {
            return _messages.RemoveAll(m => m.SenderId == userId || m.ReceiverId == userId);
        }

        public Message? GetMessageById(Guid id)
        {
            return _messages.SingleOrDefault(m => m.Id == id);
        }

        public List<Message> GetMessages(Guid? senderId, Guid? receiverId)
        {
            return _messages
                .Where(m => (senderId == null || m.SenderId == senderId) &&
                            (receiverId == null || m.ReceiverId == receiverId))
                .ToList();
        }

        public List<Message> GetConversation(Guid userId, Guid otherUserId)
        {
            return _messages
                .Where(m => (m.SenderId == userId && m.ReceiverId == otherUserId) ||
                            (m.SenderId == otherUserId && m.ReceiverId == userId))
                .ToList();
        }
    }
}
