using EventHub.Configurations;
using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EventHub
{
    public class EventHubContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // الطريقة الأولى Configuration منفصلة
            modelBuilder.ApplyConfiguration(new OrganizerProfileConfiguration());
            modelBuilder.ApplyConfiguration(new BadgeConfiguration());

            // مباشرة في OnModelCreating
            modelBuilder.Entity<Event>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.Title).IsRequired();
                e.Property(x => x.Description).IsRequired();

                // Organizer -> Events
                e.HasOne(x => x.Organizer)
                 .WithMany(o => o.Events)
                 .HasForeignKey(x => x.OrganizerId);
            });
        }
    }
}