using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.Dtos
{
    public class CreateNotificationDto : IValidatableObject
    {
        public required Guid UserId { get; set; }

        [Required]
        [RegularExpression("^(Like|Comment|Mention|FriendRequest|System)$",
            ErrorMessage = "Type must be one of: Like, Comment, Mention, FriendRequest, System.")]
        public required string Type { get; set; }

        // The user who caused the notification. Required for every type except System.
        public Guid? TriggeredByUserId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Type != "System" && TriggeredByUserId == null)
            {
                yield return new ValidationResult(
                    "TriggeredByUserId is required for this notification type.",
                    new[] { nameof(TriggeredByUserId) });
            }
        }
    }
}
