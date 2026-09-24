using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{

    // api/likes
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {

        public LikesController() { }


        // GET /api/likes?userId={userId}&tweetId={tweetId}
        [HttpGet]
        public IActionResult GetLikes([FromQuery] Guid? userId, [FromQuery] Guid? tweetId)
        {
            return Ok(new List<object>
            {
                new
                {
                    LikeId = Guid.NewGuid(),
                    UserId = userId ?? Guid.NewGuid(),
                    TweetId = tweetId ?? Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow.AddMinutes(-30),
                },
                new
                {
                    LikeId = Guid.NewGuid(),
                    UserId = userId ?? Guid.NewGuid(),
                    TweetId = tweetId ?? Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow.AddMinutes(-10),
                },
            });
        }

        // GET /api/likes/{id}
        [HttpGet("{id}")]
        public IActionResult GetLikeById([FromRoute] Guid id)
        {
            return Ok(new
            {
                LikeId = id,
                UserId = Guid.NewGuid(),
                TweetId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        }

        // POST /api/likes
        [HttpPost]
        public IActionResult CreateLike()
        {
            return Ok(new
            {
                LikeId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                TweetId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        }

        // DELETE /api/likes/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteLike([FromRoute] Guid id)
        {
            return Ok(new
            {
                LikeId = id,
                Message = "Like removed successfully.",
            });
        }
    }
}
