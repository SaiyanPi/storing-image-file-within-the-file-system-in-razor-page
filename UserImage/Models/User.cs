using System.ComponentModel.DataAnnotations;

namespace UserImage.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Contact { get; set; }

        [Required (ErrorMessage = "You must provide a Date of Birth")]
        [Display(Name = "Date of Birth")]
        public DateTime DoB { get; set; }

        public string ImageName { get; set; }
    }

}

