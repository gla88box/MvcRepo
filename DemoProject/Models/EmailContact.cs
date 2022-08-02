using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class EmailContact : Contact
    {
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Email Address is required.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Email Address is not a valid length.")]
        public string EmailAddress { get; set; }
    }
}
