using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class LikeRepository : ILikeRepository
    {

        private readonly List<Like> _likes = new List<Like>();

        public Like AddLike(Like like)
        {
            _likes.Add(like);

            return like;
        }

        public bool DeleteLike(Like like)
        {
            return _likes.Remove(like);
        }

        public int DeleteLikesByUserId(Guid userId)
        {
            return _likes.RemoveAll(l => l.UserId == userId);
        }

        public int DeleteLikesByTweetId(Guid tweetId)
        {
            return _likes.RemoveAll(l => l.TweetId == tweetId);
        }

        public Like? GetLikeById(Guid id)
        {
            return _likes.SingleOrDefault(l => l.Id == id);
        }

        public Like? GetLikeByUserAndTweet(Guid userId, Guid tweetId)
        {
            return _likes.FirstOrDefault(l => l.UserId == userId && l.TweetId == tweetId);
        }

        public List<Like> GetLikes(Guid? userId, Guid? tweetId)
        {
            return _likes
                .Where(l => (userId == null || l.UserId == userId) &&
                            (tweetId == null || l.TweetId == tweetId))
                .ToList();
        }
    }
}
