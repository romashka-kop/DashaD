using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DashaD.Models
{
    public class PaymentsDuties //платежки за пошлины
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPayDuties { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        public DateOnly DatePay { get; set; }
    }
}
