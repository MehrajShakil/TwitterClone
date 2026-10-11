using TwitterClone.Application.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Mappings
{
    public static class MappingExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CreatedAt = user.CreatedAt,
                ModifiedAt = user.ModifiedAt
            };
        }

        public static TweetDto ToDto(this Tweet tweet)
        {
            return new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content,
                CreatedAt = tweet.CreatedAt,
                ModifiedAt = tweet.ModifiedAt
            };
        }

        public static BookmarkDto ToDto(this Bookmark bookmark)
        {
            return new BookmarkDto
            {
                Id = bookmark.Id,
                UserId = bookmark.UserId,
                TweetId = bookmark.TweetId,
                CreatedAt = bookmark.CreatedAt
            };
        }

        public static LikeDto ToDto(this Like like)
        {
            return new LikeDto
            {
                Id = like.Id,
                UserId = like.UserId,
                TweetId = like.TweetId,
                CreatedAt = like.CreatedAt
            };
        }

        public static FollowDto ToDto(this Follow follow)
        {
            return new FollowDto
            {
                Id = follow.Id,
                FollowerId = follow.FollowerId,
                FollowingId = follow.FollowingId,
                CreatedAt = follow.CreatedAt
            };
        }

        public static RetweetDto ToDto(this Retweet retweet)
        {
            return new RetweetDto
            {
                Id = retweet.Id,
                UserId = retweet.UserId,
                TweetId = retweet.TweetId,
                Comment = retweet.Comment,
                CreatedAt = retweet.CreatedAt,
                ModifiedAt = retweet.ModifiedAt
            };
        }

        public static MessageDto ToDto(this Message message)
        {
            return new MessageDto
            {
                Id = message.Id,
                SenderId = message.SenderId,
                ReceiverId = message.ReceiverId,
                Content = message.Content,
                SentAt = message.SentAt,
                IsRead = message.IsRead,
                ModifiedAt = message.ModifiedAt
            };
        }

        public static NotificationDto ToDto(this Notification notification)
        {
            return new NotificationDto
            {
                Id = notification.Id,
                UserId = notification.UserId,
                Type = notification.Type,
                Message = notification.GetMessage(),
                IsRead = notification.IsRead,
                CreatedAt = notification.CreatedAt,
                ModifiedAt = notification.ModifiedAt
            };
        }
    }
}
