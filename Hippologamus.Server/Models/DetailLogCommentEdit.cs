using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hippologamus.Server.Models
{
    public class DetailLogCommentEdit : IValidatableObject
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public bool LinkedToDevOps { get; set; }
        public string DevOpsId { get; set; }
        public string CreateadBy { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (LinkedToDevOps = true && string.IsNullOrWhiteSpace(DevOpsId))
            {
                errors.Add(new ValidationResult("If linked to a dev ops itm, you must provide a devops Id.", new[] { nameof(DevOpsId) }));
            }
            return errors;
        }
    }
}