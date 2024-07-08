

namespace WebProject.Models
{
    public class BucketItem
    {
        public int Id { get; set; }
        public int PresentId { get; set; }
        public int BucketId { get; set; }
        public bool Status { get; set; } = false;
        public int? Quantity { get; set; }
        public Bucket Bucket { get; set; }
        public Present Present { get; set; }
    }
}