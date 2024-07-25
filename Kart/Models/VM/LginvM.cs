using System.ComponentModel.DataAnnotations;

namespace Kart.Models.VM
{
    public class LginvM
    {
        [Required]
        [EmailAddress]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
