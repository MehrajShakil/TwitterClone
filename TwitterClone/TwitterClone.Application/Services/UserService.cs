using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITweetRepository _tweetRepository;
        private readonly ITweetService _tweetService;
        private readonly ILikeRepository _likeRepository;
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IRetweetRepository _retweetRepository;
        private readonly IFollowRepository _followRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly INotificationRepository _notificationRepository;

        public UserService(
            IUserRepository userRepository,
            ITweetRepository tweetRepository,
            ITweetService tweetService,
            ILikeRepository likeRepository,
            IBookmarkRepository bookmarkRepository,
            IRetweetRepository retweetRepository,
            IFollowRepository followRepository,
            IMessageRepository messageRepository,
            INotificationRepository notificationRepository)
        {
            _userRepository = userRepository;
            _tweetRepository = tweetRepository;
            _tweetService = tweetService;
            _likeRepository = likeRepository;
            _bookmarkRepository = bookmarkRepository;
            _retweetRepository = retweetRepository;
            _followRepository = followRepository;
            _messageRepository = messageRepository;
            _notificationRepository = notificationRepository;
        }

        public UserDto? CreateUser(CreateUserDto createUserDto)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.FirstName) ||
               string.IsNullOrWhiteSpace(createUserDto.LastName) ||
               string.IsNullOrWhiteSpace(createUserDto.Email))
            {
                return null;
            }

            var existingUser = _userRepository.GetUserByEmail(createUserDto.Email);

            if (existingUser != null)
            {
                return null;
            }

            var createdUser = _userRepository.AddUser(new User()
            {
                FirstName = createUserDto.FirstName.Trim(),
                LastName = createUserDto.LastName.Trim(),
                Email = createUserDto.Email.Trim()
            });

            return createdUser.ToDto();
        }

        public bool DeleteUser(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return false;
            }

            // A user's tweets can't outlive the user. Going through the tweet service
            // also removes the likes, bookmarks and retweets other users left on them.
            foreach (var tweet in _tweetRepository.GetTweetsByUserId(id))
            {
                _tweetService.DeleteTweet(tweet.Id);
            }

            // Neither can the user's own activity and relationships.
            _likeRepository.DeleteLikesByUserId(id);
            _bookmarkRepository.DeleteBookmarksByUserId(id);
            _retweetRepository.DeleteRetweetsByUserId(id);
            _followRepository.DeleteFollowsByUserId(id);
            _messageRepository.DeleteMessagesByUserId(id);
            _notificationRepository.DeleteNotificationsByUserId(id);

            return _userRepository.DeleteUser(user);
        }

        public UserDto? GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            return user?.ToDto();
        }

        public List<UserDto> GetUsers()
        {
            return _userRepository.GetUsers()
                .OrderBy(u => u.CreatedAt)
                .Select(u => u.ToDto())
                .ToList();
        }

        public UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return null;
            }

            user.FirstName = updateUserDto.FirstName.Trim();
            user.LastName = updateUserDto.LastName.Trim();
            user.MarkAsModified();

            _userRepository.UpdateUser(user);

            return user.ToDto();
        }

        public UserDto? UpdateUserPhoneNumber(Guid id, string phoneNumber)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return null;
            }

            user.PhoneNumber = phoneNumber.Trim();
            user.MarkAsModified();

            _userRepository.UpdateUser(user);

            return user.ToDto();
        }
    }
}
