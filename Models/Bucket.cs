namespace WebProject.Models
{
    public class Bucket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public int Sum { get; set; }
        
        //public ICollection<PresentsOrder>? PresentsOrder { get; set; }
    }
}
