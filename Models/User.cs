using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public enum Role
    {
        User,
        Admin,
        
    }
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        public string Password { get; set; }
        [MinLength(2)]
        public string? FullName { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public Role Role { get; set; } = Role.User;
    }
}
