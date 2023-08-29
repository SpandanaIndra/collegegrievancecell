using Microsoft.EntityFrameworkCore;

namespace Core_CollegeGrievanceCell.Models
{
    public class CollegeDbContext:DbContext
    {
        public CollegeDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<DetailsByAdmin> UserDetailsByAdmin { get; set; }
        public DbSet<User> Users { get; set; }
         public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(d => d.DetailsByAdmin)
                .WithOne(u => u.User)
                .HasForeignKey<User>(u => u.UserId); // Specify the foreign key property

            // Other configurations...
        }
    }
}
