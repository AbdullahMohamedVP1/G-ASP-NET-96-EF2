using EventHub;
using EventHub.Models;

namespace Ef2_assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new EventHubContext();

            var organizer = new Organizer{
                Name = "Ahmed Ali",
                CompanyName = "Tech Events",
                IsVerified = true,
                Profile = new OrganizerProfile{
                    Biography = "We organize events",
                    WebsiteUrl = "https://example.com",
                    LogoUrl = "logo.png" }
            };

            organizer.Events.Add(new Event{
                Title = "EF Core Workshop",
                Description = "Workshop about EF Core",
                StartDate = DateTime.Now.AddDays(10),
                MaxAttendees = 100});

            var attendee = new Attendee{
                FullName = "Abdallah Mohamed",
                Email = "test@example.com",
                Street = "Street 1",
                City = "Banha",
                Country = "Egypt",
                PostalCode = "13511",
                Badge = new Badge{
                    BadgeNumber = 1,
                    IssuedDate = DateTime.Now,
                    Tier = BadgeTier.VIP}};

            db.Organizers.Add(organizer);
            db.Attendees.Add(attendee);
            db.SaveChanges();

            Console.WriteLine(attendee.FullAddress);
        }
    }
}