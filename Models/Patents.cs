using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DashaD.Models
{
    public class Patents //патент
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPatent { get; set; }
        [Required]
        public long Number { get; set; }
        [Required]
        public string PatentName { get; set; }
        [Required]
        public DateOnly DatePriority { get; set; }
        [Required]
        public DateOnly DateRegistration { get; set; }
        [Required]
        public DateOnly DateFinal { get; set; }
        [Required]
        public int IdActComparingAnalysis { get; set; }
        [Required]
        public int IdActImplementation { get; set; }
        [Required]
        public int IdBid { get; set; }
        //public virtual ActComparingAnalysis Act_Comparing_Analysis { get; set; }
        //public virtual ActImplementation Act_Implementation { get; set; }
        //public virtual Bid Request { get; set; }

    }
}
