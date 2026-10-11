using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.Dtos
{
    public class CreateRetweetDto : IValidatableObject
    {
        public required Guid UserId { get; set; }
        public required Guid TweetId { get; set; }

        // Optional: a retweet without a comment is a plain retweet.
        public string? Comment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return RetweetCommentValidator.Validate(Comment, nameof(Comment));
        }
    }
}
