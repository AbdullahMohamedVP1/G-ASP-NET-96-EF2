using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.Models
{
    public class Attendee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(150)]
        public string Street { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("ZipCode")]
        public string PostalCode { get; set; }

        [NotMapped]
        public string FullAddress => $"{Street}, {City}, {Country}, {PostalCode}";

        public Badge Badge { get; set; }   // One-to-One
    }
}