
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebProject.Models;

namespace WebProject.DTO
{
    public class PresentDTO
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int DonorId { get; set; }
        public int Cost { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }
    }
}
