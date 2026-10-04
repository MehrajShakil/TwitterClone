using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface ITweetService
    {
        TweetDto? CreateTweet(CreateTweetDto createTweetDto);
        TweetDto? GetTweetById(Guid id);
        List<TweetDto> GetTweets(Guid? userId);
        TweetDto? UpdateTweet(Guid id, UpdateTweetDto updateTweetDto);
        bool DeleteTweet(Guid id);
    }
}
