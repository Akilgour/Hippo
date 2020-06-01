using Hippologamus.Server.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hippologamus.Server.Models
{
    public class DeleteItem
    {
        public string DialogTitle { get; set; }
        public string DeleteCaption { get; set; }

        [DisplayName("Check value")]
        public string CheckValue { get; set; }

        [Required(ErrorMessage = "You must enter a value.")]
        [MustMatch("CheckValue")]
        [DisplayName("Entered value")]
        public string UserValue { get; set; }
    }
}