using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashaD.Models
{
    public class Authors //автор
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAuthor { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string NumberPhone { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string FullName { get; set; } //AS (Surname + ' ' + Name + ' ' + Patronymic)
        public List<Patents> Patent { get; set; }
        public List<Bid> Bids { get; set; }
    }
}
