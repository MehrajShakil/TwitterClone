using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{

    // api/retweets
    [Route("api/[controller]")]
    [ApiController]
    public class RetweetsController : ControllerBase
    {

        public RetweetsController() { }


        // GET /api/retweets?userId={userId}&tweetId={tweetId}
        [HttpGet]
        public IActionResult GetRetweets([FromQuery] Guid? userId, [FromQuery] Guid? tweetId)
        {
            return Ok(new List<object>
            {
                new
                {
                    RetweetId = Guid.NewGuid(),
                    UserId = userId ?? Guid.NewGuid(),
                    TweetId = tweetId ?? Guid.NewGuid(),
                    Comment = "Great point!",
                    CreatedAt = DateTime.UtcNow.AddHours(-3),
                },
                new
                {
                    RetweetId = Guid.NewGuid(),
                    UserId = userId ?? Guid.NewGuid(),
                    TweetId = tweetId ?? Guid.NewGuid(),
                    Comment = "",
                    CreatedAt = DateTime.UtcNow.AddHours(-1),
                },
            });
        }

        // GET /api/retweets/{id}
        [HttpGet("{id}")]
        public IActionResult GetRetweetById([FromRoute] Guid id)
        {
            return Ok(new
            {
                RetweetId = id,
                UserId = Guid.NewGuid(),
                TweetId = Guid.NewGuid(),
                Comment = "retweet" + id.ToString(),
                CreatedAt = DateTime.UtcNow,
            });
        }

        // POST /api/retweets
        [HttpPost]
        public IActionResult CreateRetweet()
        {
            return Ok(new
            {
                RetweetId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                TweetId = Guid.NewGuid(),
                Comment = "New retweet comment.",
                CreatedAt = DateTime.UtcNow,
            });
        }

        // PUT /api/retweets/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateRetweet([FromRoute] Guid id)
        {
            return Ok(new
            {
                RetweetId = id,
                UserId = Guid.NewGuid(),
                TweetId = Guid.NewGuid(),
                Comment = "updatedcomment" + id.ToString(),
                ModifiedAt = DateTime.UtcNow,
            });
        }

        // DELETE /api/retweets/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteRetweet([FromRoute] Guid id)
        {
            return Ok(new
            {
                RetweetId = id,
                Message = "Retweet removed successfully.",
            });
        }
    }
}
