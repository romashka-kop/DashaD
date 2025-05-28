using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashaD.Models
{
    public class Payments //платежки
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPay { get; set; }
        [Required]
        public string File { get; set; }
    }
}
