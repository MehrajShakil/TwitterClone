using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IFollowRepository
    {
        Follow AddFollow(Follow follow);
        bool DeleteFollow(Follow follow);
        int DeleteFollowsByUserId(Guid userId);
        Follow? GetFollowById(Guid id);
        Follow? GetFollowByUsers(Guid followerId, Guid followingId);
        List<Follow> GetFollows(Guid? followerId, Guid? followingId);
    }
}
