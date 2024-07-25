using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Kart.Models.VM
{
    public class UserVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the FirstName")]
        [StringLength(40)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the LastName")]
        [StringLength(40)]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please enter the EmailId")]
        [EmailAddress(ErrorMessage = "Invalid email format")]

        public string? EmailId { get; set; }
        [Required(ErrorMessage = "Please enter the Password")]
        [StringLength(8)]
        [MinLength(4)]
        [PasswordPropertyText]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Please enter the Address")]
        [StringLength(500)]
        public string? Address { get; set; }
    }
}
