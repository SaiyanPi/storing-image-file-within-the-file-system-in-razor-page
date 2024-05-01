using System.ComponentModel.DataAnnotations;

namespace UserImage.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public DateTime DoB { get; set; }
        public string ImageName { get; set; }
    }

}

