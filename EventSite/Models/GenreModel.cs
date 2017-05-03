using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventSite.Models
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EventModel> Events { get; set; } = new HashSet<EventModel>();
    }
}