using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DashaD.Models
{
    public class Agreement //договор
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgreement { get; set; }
        [Required]
        public TypesAgreement Type { get; set; }
        [Required]
        public string AgreementName { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public long AgreementNumber { get; set; }
        [Required]
        public DateOnly DateAgreement { get; set; }
        public int IdActUse { get; set; }
        public int IdAgreementCreation { get; set; }
        //public virtual ActUse Act_Use { get; set; }
        //public virtual AgreementCreation Agreement_Creation { get; set; }

        public enum TypesAgreement { agreement, act}
    }
}
