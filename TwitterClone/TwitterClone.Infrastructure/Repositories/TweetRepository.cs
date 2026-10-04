using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class TweetRepository : ITweetRepository
    {

        private readonly List<Tweet> _tweets = new List<Tweet>();

        public Tweet AddTweet(Tweet tweet)
        {
            _tweets.Add(tweet);

            return tweet;
        }

        public Tweet UpdateTweet(Tweet tweet)
        {
            _tweets.RemoveAll(t => t.Id == tweet.Id);
            _tweets.Add(tweet);
            return tweet;
        }

        public bool DeleteTweet(Tweet tweet)
        {
            return _tweets.Remove(tweet);
        }

        public int DeleteTweetsByUserId(Guid userId)
        {
            return _tweets.RemoveAll(t => t.UserId == userId);
        }

        public Tweet? GetTweetById(Guid id)
        {
            return _tweets.SingleOrDefault(t => t.Id == id);
        }

        public List<Tweet> GetTweets()
        {
            return _tweets.ToList();
        }

        public List<Tweet> GetTweetsByUserId(Guid userId)
        {
            return _tweets.Where(t => t.UserId == userId).ToList();
        }
    }
}
