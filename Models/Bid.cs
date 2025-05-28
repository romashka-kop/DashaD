using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashaD.Models
{
    public class Bid //заявка
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBid { get; set; }
        [Required]
        public long BidNumber { get; set; }
        [Required]
        public DateOnly DateBid { get; set; }
        [Required]
        public string Letter { get; set; }
        [Required]
        public string Formula { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Report { get; set; }
        [Required]
        public string NumberDate { get; set; }

        public List<Notification> Notify { get; set; }
        public List<Payments> Payment { get; set; }
        public List<Authors> Author { get; set; }
    }
}
