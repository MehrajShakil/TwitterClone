using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class BookmarkRepository : IBookmarkRepository
    {

        private readonly List<Bookmark> _bookmarks = new List<Bookmark>();

        public Bookmark AddBookmark(Bookmark bookmark)
        {
            _bookmarks.Add(bookmark);

            return bookmark;
        }

        public bool DeleteBookmark(Bookmark bookmark)
        {
            return _bookmarks.Remove(bookmark);
        }

        public int DeleteBookmarksByUserId(Guid userId)
        {
            return _bookmarks.RemoveAll(b => b.UserId == userId);
        }

        public int DeleteBookmarksByTweetId(Guid tweetId)
        {
            return _bookmarks.RemoveAll(b => b.TweetId == tweetId);
        }

        public Bookmark? GetBookmarkById(Guid id)
        {
            return _bookmarks.SingleOrDefault(b => b.Id == id);
        }

        public Bookmark? GetBookmarkByUserAndTweet(Guid userId, Guid tweetId)
        {
            return _bookmarks.FirstOrDefault(b => b.UserId == userId && b.TweetId == tweetId);
        }

        public List<Bookmark> GetBookmarks(Guid? userId)
        {
            return _bookmarks
                .Where(b => userId == null || b.UserId == userId)
                .ToList();
        }
    }
}
