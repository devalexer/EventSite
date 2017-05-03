using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EventSite.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }

        public int VenueId { get; set; }
        public Menu Venue { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}