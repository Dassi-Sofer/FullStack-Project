

using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public enum TypeOfDonation
    {
        Present, Money
    }
    public class Donor
    {
        
        public int Id { get; set; }
        [MinLength(2)]
        public string Name { get; set; }
        public string? Phone { get; set; }
        [MinLength(4)]
        public string? Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public TypeOfDonation TypeOfDonation { get; set; }
    }
}
