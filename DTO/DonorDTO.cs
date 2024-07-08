using System.ComponentModel.DataAnnotations;

namespace WebProject.DTO
{
    public class DonorDTO
    {
        [Required]
        public string Name { get; set; }
        [StringLength(maximumLength: 10)]
        public string? Phone { get; set; }
        [StringLength(30)]
        public string? Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
