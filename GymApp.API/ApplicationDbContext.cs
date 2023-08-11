namespace GymApp.API
{
    using Microsoft.EntityFrameworkCore;
    using Models.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base (options)
        {         
        }

        public DbSet<Members> Members { get; set; }

        public DbSet<MemberBmiRecord> BmiRecords { get; set; }

        public DbSet<MemberHrRecord> HrRecords { get; set; }

        public DbSet<Trainers> Trainers { get; set; }

        public DbSet<MemberTrainerLink> MemberTrainerLink { get; set; }

    }
}
