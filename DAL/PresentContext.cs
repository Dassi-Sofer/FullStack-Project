

using WebProject.Models;

namespace WebProject.DAL
{
    public class PresentContext:DbContext
    {
        public PresentContext(DbContextOptions<PresentContext> options) : base(options)
        {

        }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Present> Present { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Bucket>Bucket { get; set; }
        public DbSet<BucketItem> BucketItem { get; set; }
        public DbSet<Winner> Winner { get; set; }


    }
}
