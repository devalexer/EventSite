using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventSite.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<TicketModel> Ticket { get; set; } = new HashSet<TicketModel>();
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int MyProperty { get; set; }

    }
}