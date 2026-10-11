using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface ILikeService
    {
        LikeDto? CreateLike(CreateLikeDto createLikeDto);
        LikeDto? GetLikeById(Guid id);
        List<LikeDto> GetLikes(Guid? userId, Guid? tweetId);
        bool DeleteLike(Guid id);
    }
}
