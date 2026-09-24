using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwittersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TwittersController(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetTweets()
        {
            var tweets = new List<object>
            {
                new
                {
                    UserId = Guid.NewGuid(),
                    Content = "Hello, world!",
                },
                new
                {
                    UserId = Guid.NewGuid(),
                    Content = "This is my second tweet.",
                },
            };

            return Ok(tweets);
        }
    }
}


