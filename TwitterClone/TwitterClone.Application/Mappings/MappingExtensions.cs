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
    }
}
