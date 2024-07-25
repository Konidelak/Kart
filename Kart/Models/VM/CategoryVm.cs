using System.ComponentModel.DataAnnotations;

namespace Kart.Models.VM
{
    public class CategoryVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the name")]
        [StringLength(40)]

        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter the Description")]
        [StringLength(500)]

        public string? Description { get; set; }
    }
}
