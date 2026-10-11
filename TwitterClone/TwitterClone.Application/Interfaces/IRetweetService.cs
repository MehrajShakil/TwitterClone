using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IRetweetService
    {
        RetweetDto? CreateRetweet(CreateRetweetDto createRetweetDto);
        RetweetDto? GetRetweetById(Guid id);
        List<RetweetDto> GetRetweets(Guid? userId, Guid? tweetId);
        RetweetDto? UpdateRetweet(Guid id, UpdateRetweetDto updateRetweetDto);
        bool DeleteRetweet(Guid id);
    }
}
