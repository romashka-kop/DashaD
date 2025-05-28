using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashaD.Models
{
    public class ActImplementation //акт внедрения
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdActImplementation { get; set; }
        [Required]
        public long ActNumber { get; set; }
        [Required]
        public DateOnly DateAct { get; set; }
    }
}
