using System.ComponentModel.DataAnnotations;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Dtos
{
    // A retweet comment follows the same length rule as a tweet, but may be empty.
    internal static class RetweetCommentValidator
    {
        public static IEnumerable<ValidationResult> Validate(string? comment, string memberName)
        {
            if (comment != null && comment.Length > Tweet.MaxContentLength)
            {
                yield return new ValidationResult(
                    $"Retweet comment cannot be longer than {Tweet.MaxContentLength} characters.",
                    new[] { memberName });
            }
        }
    }
}
