using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class TelephoneContact : Contact
    {
        [DisplayName("Telephone Number")]
        [Required(ErrorMessage = "Telephone Number is required.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Telephone Number is not a valid length.")]
        public string TelephoneNumber { get; set; }

        public bool IsLandLine { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string ExtensionNumber { get; set; }
    }
}
