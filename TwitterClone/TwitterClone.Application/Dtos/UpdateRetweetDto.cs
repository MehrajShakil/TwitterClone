using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.Dtos
{
    public class UpdateRetweetDto : IValidatableObject
    {
        public string? Comment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return RetweetCommentValidator.Validate(Comment, nameof(Comment));
        }
    }
}
