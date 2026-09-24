using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{

    // api/tweets
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {

        public TweetsController() { }


        // GET /api/tweets?userId={userId}
        [HttpGet]
        public IActionResult GetTweets([FromQuery] Guid? userId)
        {
            return Ok(new List<object>
            {
                new
                {
                    TweetId = Guid.NewGuid(),
                    UserId = userId ?? Guid.NewGuid(),
                    Content = "Hello, world!",
                    CreatedAt = DateTime.UtcNow.AddHours(-2),
                },
                new
                {
                    TweetId = Guid.NewGuid(),
                    UserId = userId ?? Guid.NewGuid(),
                    Content = "This is my second tweet.",
                    CreatedAt = DateTime.UtcNow.AddHours(-1),
                },
            });
        }

        // GET /api/tweets/{id}
        [HttpGet("{id}")]
        public IActionResult GetTweetById([FromRoute] Guid id)
        {
            return Ok(new
            {
                TweetId = id,
                UserId = Guid.NewGuid(),
                Content = "tweet" + id.ToString(),
                CreatedAt = DateTime.UtcNow,
            });
        }

        // POST /api/tweets
        [HttpPost]
        public IActionResult CreateTweet()
        {
            return Ok(new
            {
                TweetId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Content = "New tweet content.",
                CreatedAt = DateTime.UtcNow,
            });
        }

        // PUT /api/tweets/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTweet([FromRoute] Guid id)
        {
            return Ok(new
            {
                TweetId = id,
                UserId = Guid.NewGuid(),
                Content = "updatedtweet" + id.ToString(),
                ModifiedAt = DateTime.UtcNow,
            });
        }

        // DELETE /api/tweets/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            return Ok(new
            {
                TweetId = id,
                Message = "Tweet deleted successfully.",
            });
        }
    }
}
