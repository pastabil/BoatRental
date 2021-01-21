using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRental.Models
{
    public class BookNowDatabase
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="BookingCalendar"),DisplayFormat(DataFormatString="{0:dd.MM.yyyy}")]
        public DateTime Calendar { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public string TripLength { get; set; }

        [Required]
        public bool Food { get; set; }
        
        [Required]
        public bool Drinks { get; set; }

        [Required]
        public bool TourGuide { get; set; }

        [Required]
        public string Payment { get; set; }
    }
}