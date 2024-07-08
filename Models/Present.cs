

namespace WebProject.Models
{
   public enum Category
    {
        Furniture, Vacation, Clothing, Events
    }
    public class Present
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DonorId { get; set; }
        public int Cost { get; set; }
        public int Quentity { get; set; }
        public bool isRuffled { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }
        public Donor Donor { get; set; }
    }
}


