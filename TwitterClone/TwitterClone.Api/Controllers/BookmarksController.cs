using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{

    // api/bookmarks
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {

        public BookmarksController() { }


        // GET /api/bookmarks?userId={userId}
        [HttpGet]
        public IActionResult GetBookmarks([FromQuery] Guid? userId)
        {
            return Ok(new List<object>
            {
                new
                {
                    BookmarkId = Guid.NewGuid(),
                    UserId = userId ?? Guid.NewGuid(),
                    TweetId = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                },
                new
                {
                    BookmarkId = Guid.NewGuid(),
                    UserId = userId ?? Guid.NewGuid(),
                    TweetId = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                },
            });
        }

        // GET /api/bookmarks/{id}
        [HttpGet("{id}")]
        public IActionResult GetBookmarkById([FromRoute] Guid id)
        {
            return Ok(new
            {
                BookmarkId = id,
                UserId = Guid.NewGuid(),
                TweetId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        }

        // POST /api/bookmarks
        [HttpPost]
        public IActionResult CreateBookmark()
        {
            return Ok(new
            {
                BookmarkId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                TweetId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        }

        // DELETE /api/bookmarks/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBookmark([FromRoute] Guid id)
        {
            return Ok(new
            {
                BookmarkId = id,
                Message = "Bookmark removed successfully.",
            });
        }
    }
}
