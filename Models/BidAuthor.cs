using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DashaD.Models
{
    public class BidAuthor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdAuthor { get; set; }
        public int IdBid { get; set; }
    }
}
