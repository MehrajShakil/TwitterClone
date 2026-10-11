using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITweetRepository _tweetRepository;

        public LikeService(
            ILikeRepository likeRepository,
            IUserRepository userRepository,
            ITweetRepository tweetRepository)
        {
            _likeRepository = likeRepository;
            _userRepository = userRepository;
            _tweetRepository = tweetRepository;
        }

        public LikeDto? CreateLike(CreateLikeDto createLikeDto)
        {
            var user = _userRepository.GetUserById(createLikeDto.UserId);
            var tweet = _tweetRepository.GetTweetById(createLikeDto.TweetId);

            if (user == null || tweet == null || !tweet.CanBeLiked())
            {
                return null;
            }

            // Liking the same tweet twice is a no-op: hand back the existing like.
            var existingLike = _likeRepository.GetLikeByUserAndTweet(user.Id, tweet.Id);

            if (existingLike != null)
            {
                return existingLike.ToDto();
            }

            var createdLike = _likeRepository.AddLike(new Like()
            {
                UserId = user.Id,
                TweetId = tweet.Id
            });

            return createdLike.ToDto();
        }

        public LikeDto? GetLikeById(Guid id)
        {
            var like = _likeRepository.GetLikeById(id);

            return like?.ToDto();
        }

        public List<LikeDto> GetLikes(Guid? userId, Guid? tweetId)
        {
            return _likeRepository.GetLikes(userId, tweetId)
                .OrderByDescending(l => l.CreatedAt)
                .Select(l => l.ToDto())
                .ToList();
        }

        public bool DeleteLike(Guid id)
        {
            var like = _likeRepository.GetLikeById(id);

            if (like == null)
            {
                return false;
            }

            return _likeRepository.DeleteLike(like);
        }
    }
}
