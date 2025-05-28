using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashaD.Models
{
    public class AgreementCreation //договор за создание
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgreementCreation { get; set; }
        [Required]
        public long AgreementNumber { get; set; }
        [Required]
        public DateOnly DateAgreement { get; set; }
        [Required]
        public string File { get; set; }
    }
}
