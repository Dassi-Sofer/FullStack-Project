using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Winner
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PresentId { get; set; }
        public Present Present { get; set; }
        public User User { get; set; }
    }
}
