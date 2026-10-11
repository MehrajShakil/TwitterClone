using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class RetweetService : IRetweetService
    {
        private readonly IRetweetRepository _retweetRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITweetRepository _tweetRepository;

        public RetweetService(
            IRetweetRepository retweetRepository,
            IUserRepository userRepository,
            ITweetRepository tweetRepository)
        {
            _retweetRepository = retweetRepository;
            _userRepository = userRepository;
            _tweetRepository = tweetRepository;
        }

        public RetweetDto? CreateRetweet(CreateRetweetDto createRetweetDto)
        {
            if (!IsValidComment(createRetweetDto.Comment))
            {
                return null;
            }

            if (_userRepository.GetUserById(createRetweetDto.UserId) == null ||
                _tweetRepository.GetTweetById(createRetweetDto.TweetId) == null)
            {
                return null;
            }

            var createdRetweet = _retweetRepository.AddRetweet(new Retweet()
            {
                UserId = createRetweetDto.UserId,
                TweetId = createRetweetDto.TweetId,
                Comment = createRetweetDto.Comment?.Trim() ?? string.Empty
            });

            return createdRetweet.ToDto();
        }

        public RetweetDto? GetRetweetById(Guid id)
        {
            var retweet = _retweetRepository.GetRetweetById(id);

            return retweet?.ToDto();
        }

        public List<RetweetDto> GetRetweets(Guid? userId, Guid? tweetId)
        {
            return _retweetRepository.GetRetweets(userId, tweetId)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => r.ToDto())
                .ToList();
        }

        public RetweetDto? UpdateRetweet(Guid id, UpdateRetweetDto updateRetweetDto)
        {
            if (!IsValidComment(updateRetweetDto.Comment))
            {
                return null;
            }

            var retweet = _retweetRepository.GetRetweetById(id);

            if (retweet == null)
            {
                return null;
            }

            retweet.Comment = updateRetweetDto.Comment?.Trim() ?? string.Empty;
            retweet.MarkAsModified();

            _retweetRepository.UpdateRetweet(retweet);

            return retweet.ToDto();
        }

        public bool DeleteRetweet(Guid id)
        {
            var retweet = _retweetRepository.GetRetweetById(id);

            if (retweet == null)
            {
                return false;
            }

            return _retweetRepository.DeleteRetweet(retweet);
        }

        private static bool IsValidComment(string? comment)
        {
            return comment == null || comment.Length <= Tweet.MaxContentLength;
        }
    }
}
