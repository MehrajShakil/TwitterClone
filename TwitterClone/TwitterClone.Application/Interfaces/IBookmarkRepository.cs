using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IBookmarkRepository
    {
        Bookmark AddBookmark(Bookmark bookmark);
        bool DeleteBookmark(Bookmark bookmark);
        int DeleteBookmarksByUserId(Guid userId);
        int DeleteBookmarksByTweetId(Guid tweetId);
        Bookmark? GetBookmarkById(Guid id);
        Bookmark? GetBookmarkByUserAndTweet(Guid userId, Guid tweetId);
        List<Bookmark> GetBookmarks(Guid? userId);
    }
}
