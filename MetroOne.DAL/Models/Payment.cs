using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DAL.Models
{
    public partial  class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int TicketId { get; set; } // FK to Ticket

        [Required]
        [MaxLength(50)]
        public string Method { get; set; } // (e.g., Credit Card, Cash, etc.)

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // "Paid" or "Pending"

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        // Navigation property
        public Ticket Ticket { get; set; }
    }
}
