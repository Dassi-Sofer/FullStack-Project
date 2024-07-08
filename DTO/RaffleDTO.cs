
using WebProject.Models;

namespace WebProject.DTO
{
    public class RaffleDTO
    {
        public int UserId { get; set; }
        public User user { get; set; }
        public int PresentId { get; set; }
        public Present present { get; set; }
    }
}
