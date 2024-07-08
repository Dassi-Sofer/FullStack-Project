
using WebProject.Models;

namespace WebProject.DTO
{
    public class BucketItemDTO
    {
        public int PresentId { get; set; }
        public int BucketId { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }
    }
}
