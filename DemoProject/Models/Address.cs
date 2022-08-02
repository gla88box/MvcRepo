using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models
{
    public class Address : ModelBase
    {
        [DisplayName("Line 1")]
        [Required(ErrorMessage = "Line 1 is required.")]
        [DataType(DataType.Text)]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Line 1 is not a valid length.")]
        public string Line1 { get; set; }

        [DisplayName("Line 2")]
        [DataType(DataType.Text)]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Line 2 is not a valid length.")] 
        public string Line2 { get; set; }

        [DisplayName("Town")]
        [DataType(DataType.Text)]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Town is not a valid length.")]
        public string Town { get; set; }

        [DisplayName("County")]
        [DataType(DataType.Text)]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "County is not a valid length.")] 
        public string County { get; set; }

        [DisplayName("Postcode")]
        [Required(ErrorMessage = "Postcode is required.")]
        [DataType(DataType.PostalCode)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Postcode is not a valid length.")]
        public string Postcode { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateUsedFrom { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime? DateUsedTo { get; set; }
        public bool IsCorrespondence { get; set; }
        public bool IsBilling { get; set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
    }
}
