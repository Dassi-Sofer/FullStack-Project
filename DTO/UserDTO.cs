using System.ComponentModel.DataAnnotations;
namespace WebProject.DTO
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        public string Password { get; set; }
    }
}
