using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{

    // api/tweets
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {

        private readonly ITweetService _tweetService;

        public TweetsController(
            ITweetService tweetService)
        {
            _tweetService = tweetService;
        }


        // GET /api/tweets?userId={userId}
        [HttpGet]
        [ProducesResponseType(typeof(List<TweetDto>), StatusCodes.Status200OK)]
        public IActionResult GetTweets([FromQuery] Guid? userId)
        {
            return Ok(_tweetService.GetTweets(userId));
        }

        // GET /api/tweets/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TweetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTweetById([FromRoute] Guid id)
        {
            var tweet = _tweetService.GetTweetById(id);

            if (tweet == null)
            {
                return NotFound();
            }

            return Ok(tweet);
        }

        // POST /api/tweets
        [HttpPost]
        [ProducesResponseType(typeof(TweetDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateTweet([FromBody] CreateTweetDto createTweetDto)
        {
            var createdTweet = _tweetService.CreateTweet(createTweetDto);

            if (createdTweet == null)
            {
                // Content is already validated by [ApiController], so the only failure left is an unknown user.
                return BadRequest($"User '{createTweetDto.UserId}' does not exist.");
            }

            return CreatedAtAction(nameof(GetTweetById), new { id = createdTweet.Id }, createdTweet);
        }

        // PUT /api/tweets/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TweetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateTweet([FromRoute] Guid id, [FromBody] UpdateTweetDto updateTweetDto)
        {
            var tweet = _tweetService.UpdateTweet(id, updateTweetDto);

            if (tweet == null)
            {
                return NotFound();
            }

            return Ok(tweet);
        }

        // DELETE /api/tweets/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            var isDeleted = _tweetService.DeleteTweet(id);

            if (isDeleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
