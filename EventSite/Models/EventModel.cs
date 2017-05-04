using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventSite.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime? Time { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public string Description { get; set; }
        public string ImgUrl { get; set; }

        public int VenueId { get; set; }
        public VenueModel Venue { get; set; }

        public int GenreId { get; set; }
        public GenreModel Genre { get; set; }
    }
}