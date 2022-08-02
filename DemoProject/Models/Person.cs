using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models
{
    [Table("Person")]
    public class Person : ModelBase
    {
        public Person()
        {
            Addresses = new List<Address>();
            Contacts = new List<Contact>();
        }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        [DataType(DataType.Text)]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "First Name is not a valid length.")]
        public string FirstName { get; set; }

        [DisplayName("Second Name")]
        [DataType(DataType.Text)]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Second Name is not a valid length.")]
        public string SecondName { get; set; }

        [DisplayName("Surname")]
        [Required(ErrorMessage = "Surname is required.")]
        [DataType(DataType.Text)]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Surname is not a valid length.")] 
        public string Surname { get; set; }

        
        public List<Address> Addresses { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
