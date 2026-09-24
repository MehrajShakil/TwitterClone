using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{

    // api/follows
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : ControllerBase
    {

        public FollowsController() { }


        // GET /api/follows?followerId={followerId}&followingId={followingId}
        [HttpGet]
        public IActionResult GetFollows([FromQuery] Guid? followerId, [FromQuery] Guid? followingId)
        {
            return Ok(new List<object>
            {
                new
                {
                    FollowId = Guid.NewGuid(),
                    FollowerId = followerId ?? Guid.NewGuid(),
                    FollowingId = followingId ?? Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                },
                new
                {
                    FollowId = Guid.NewGuid(),
                    FollowerId = followerId ?? Guid.NewGuid(),
                    FollowingId = followingId ?? Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                },
            });
        }

        // GET /api/follows/{id}
        [HttpGet("{id}")]
        public IActionResult GetFollowById([FromRoute] Guid id)
        {
            return Ok(new
            {
                FollowId = id,
                FollowerId = Guid.NewGuid(),
                FollowingId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        }

        // GET /api/follows/followers/{userId}
        [HttpGet("followers/{userId}")]
        public IActionResult GetFollowers([FromRoute] Guid userId)
        {
            return Ok(new List<object>
            {
                new
                {
                    UserId = Guid.NewGuid(),
                    UserName = "follower1",
                },
                new
                {
                    UserId = Guid.NewGuid(),
                    UserName = "follower2",
                },
            });
        }

        // GET /api/follows/following/{userId}
        [HttpGet("following/{userId}")]
        public IActionResult GetFollowing([FromRoute] Guid userId)
        {
            return Ok(new List<object>
            {
                new
                {
                    UserId = Guid.NewGuid(),
                    UserName = "following1",
                },
                new
                {
                    UserId = Guid.NewGuid(),
                    UserName = "following2",
                },
            });
        }

        // POST /api/follows
        [HttpPost]
        public IActionResult CreateFollow()
        {
            return Ok(new
            {
                FollowId = Guid.NewGuid(),
                FollowerId = Guid.NewGuid(),
                FollowingId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            });
        }

        // DELETE /api/follows/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteFollow([FromRoute] Guid id)
        {
            return Ok(new
            {
                FollowId = id,
                Message = "Unfollowed successfully.",
            });
        }
    }
}
