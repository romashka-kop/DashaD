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
    public class LetterAuthor //письмо с авторами
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLetterAuthor { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public DateOnly DateLetter { get; set; }
        [Required]
        public long LetterNumber { get; set; }
        [Required]
        public string File { get; set; }
    }
}
