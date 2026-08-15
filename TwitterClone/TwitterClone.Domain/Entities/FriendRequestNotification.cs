using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities
{
    public sealed class FriendRequestNotification : Notification
    {
        public FriendRequestNotification(Guid requestedByUserId) : base("FriendRequest")
        {
            RequestedByUserId = requestedByUserId;
        }

        public Guid RequestedByUserId { get; set; }

        public void AddMessage(string message)
        {
            Message = message;
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, RequestedByUserId: {RequestedByUserId}";
        }

        public override string GetMessage()
        {
            return $"User with ID {RequestedByUserId} sent you a friend request.";
        }
    }
}
