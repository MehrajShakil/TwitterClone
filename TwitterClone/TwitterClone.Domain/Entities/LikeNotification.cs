using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities
{
    public sealed class LikeNotification : Notification
    {

        public LikeNotification(Guid likeByUserId) : base("Like")
        {
            LikeByUserId = likeByUserId;
        }

        public Guid LikeByUserId { get; set; }

        public void AddMessage(string message)
        {
            Message = message;
        }

       

        public override string GetMessage()
        {
            return $"User with ID {LikeByUserId} liked your post.";
        }
    }
}
