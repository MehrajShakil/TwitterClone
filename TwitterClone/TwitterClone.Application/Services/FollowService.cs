using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;
        private readonly IUserRepository _userRepository;

        public FollowService(
            IFollowRepository followRepository,
            IUserRepository userRepository)
        {
            _followRepository = followRepository;
            _userRepository = userRepository;
        }

        public FollowDto? CreateFollow(CreateFollowDto createFollowDto)
        {
            // Nobody follows themselves.
            if (createFollowDto.FollowerId == createFollowDto.FollowingId)
            {
                return null;
            }

            if (_userRepository.GetUserById(createFollowDto.FollowerId) == null ||
                _userRepository.GetUserById(createFollowDto.FollowingId) == null)
            {
                return null;
            }

            // Following the same user twice is a no-op: hand back the existing follow.
            var existingFollow = _followRepository.GetFollowByUsers(
                createFollowDto.FollowerId, createFollowDto.FollowingId);

            if (existingFollow != null)
            {
                return existingFollow.ToDto();
            }

            var createdFollow = _followRepository.AddFollow(new Follow()
            {
                FollowerId = createFollowDto.FollowerId,
                FollowingId = createFollowDto.FollowingId
            });

            return createdFollow.ToDto();
        }

        public FollowDto? GetFollowById(Guid id)
        {
            var follow = _followRepository.GetFollowById(id);

            return follow?.ToDto();
        }

        public List<FollowDto> GetFollows(Guid? followerId, Guid? followingId)
        {
            return _followRepository.GetFollows(followerId, followingId)
                .OrderByDescending(f => f.CreatedAt)
                .Select(f => f.ToDto())
                .ToList();
        }

        // The users who follow the given user.
        public List<UserDto> GetFollowers(Guid userId)
        {
            return GetUsers(
                _followRepository.GetFollows(null, userId).Select(f => f.FollowerId));
        }

        // The users the given user follows.
        public List<UserDto> GetFollowing(Guid userId)
        {
            return GetUsers(
                _followRepository.GetFollows(userId, null).Select(f => f.FollowingId));
        }

        public bool DeleteFollow(Guid id)
        {
            var follow = _followRepository.GetFollowById(id);

            if (follow == null)
            {
                return false;
            }

            return _followRepository.DeleteFollow(follow);
        }

        private List<UserDto> GetUsers(IEnumerable<Guid> userIds)
        {
            return userIds
                .Select(id => _userRepository.GetUserById(id))
                .OfType<User>()
                .OrderBy(u => u.CreatedAt)
                .Select(u => u.ToDto())
                .ToList();
        }
    }
}
