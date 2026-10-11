using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IRetweetRepository
    {
        Retweet AddRetweet(Retweet retweet);
        Retweet UpdateRetweet(Retweet retweet);
        bool DeleteRetweet(Retweet retweet);
        int DeleteRetweetsByUserId(Guid userId);
        int DeleteRetweetsByTweetId(Guid tweetId);
        Retweet? GetRetweetById(Guid id);
        List<Retweet> GetRetweets(Guid? userId, Guid? tweetId);
    }
}
