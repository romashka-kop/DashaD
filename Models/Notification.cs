using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashaD.Models
{
    public class Notification //уведомление
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNotification { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Addressee { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public int IdBid { get; set; }
    }
}
