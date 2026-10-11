using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface ILikeRepository
    {
        Like AddLike(Like like);
        bool DeleteLike(Like like);
        int DeleteLikesByUserId(Guid userId);
        int DeleteLikesByTweetId(Guid tweetId);
        Like? GetLikeById(Guid id);
        Like? GetLikeByUserAndTweet(Guid userId, Guid tweetId);
        List<Like> GetLikes(Guid? userId, Guid? tweetId);
    }
}
