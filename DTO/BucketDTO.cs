using System.ComponentModel.DataAnnotations;


namespace WebProject.DTO
{
    public class BucketDTO
    {
 
        [Required]
        public int UserId { get; set; }
        public int? Sum { get; set; }

    }
}
