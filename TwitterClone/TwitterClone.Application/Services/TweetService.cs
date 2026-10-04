using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IUserRepository _userRepository;

        public TweetService(
            ITweetRepository tweetRepository,
            IUserRepository userRepository)
        {
            _tweetRepository = tweetRepository;
            _userRepository = userRepository;
        }

        public TweetDto? CreateTweet(CreateTweetDto createTweetDto)
        {
            if (!IsValidContent(createTweetDto.Content))
            {
                return null;
            }

            var user = _userRepository.GetUserById(createTweetDto.UserId);

            if (user == null)
            {
                return null;
            }

            var createdTweet = _tweetRepository.AddTweet(
                new Tweet(user.Id, createTweetDto.Content.Trim()));

            return createdTweet.ToDto();
        }

        public TweetDto? GetTweetById(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            return tweet?.ToDto();
        }

        public List<TweetDto> GetTweets(Guid? userId)
        {
            var tweets = userId.HasValue
                ? _tweetRepository.GetTweetsByUserId(userId.Value)
                : _tweetRepository.GetTweets();

            // Newest first, like a timeline.
            return tweets
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => t.ToDto())
                .ToList();
        }

        public TweetDto? UpdateTweet(Guid id, UpdateTweetDto updateTweetDto)
        {
            if (!IsValidContent(updateTweetDto.Content))
            {
                return null;
            }

            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return null;
            }

            tweet.Content = updateTweetDto.Content.Trim();
            tweet.MarkAsModified();

            _tweetRepository.UpdateTweet(tweet);

            return tweet.ToDto();
        }

        public bool DeleteTweet(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return false;
            }

            return _tweetRepository.DeleteTweet(tweet);
        }

        private static bool IsValidContent(string content)
        {
            return !string.IsNullOrWhiteSpace(content) && content.Length <= Tweet.MaxContentLength;
        }
    }
}
