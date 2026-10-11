using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class RetweetRepository : IRetweetRepository
    {

        private readonly List<Retweet> _retweets = new List<Retweet>();

        public Retweet AddRetweet(Retweet retweet)
        {
            _retweets.Add(retweet);

            return retweet;
        }

        public Retweet UpdateRetweet(Retweet retweet)
        {
            _retweets.RemoveAll(r => r.Id == retweet.Id);
            _retweets.Add(retweet);
            return retweet;
        }

        public bool DeleteRetweet(Retweet retweet)
        {
            return _retweets.Remove(retweet);
        }

        public int DeleteRetweetsByUserId(Guid userId)
        {
            return _retweets.RemoveAll(r => r.UserId == userId);
        }

        public int DeleteRetweetsByTweetId(Guid tweetId)
        {
            return _retweets.RemoveAll(r => r.TweetId == tweetId);
        }

        public Retweet? GetRetweetById(Guid id)
        {
            return _retweets.SingleOrDefault(r => r.Id == id);
        }

        public List<Retweet> GetRetweets(Guid? userId, Guid? tweetId)
        {
            return _retweets
                .Where(r => (userId == null || r.UserId == userId) &&
                            (tweetId == null || r.TweetId == tweetId))
                .ToList();
        }
    }
}
