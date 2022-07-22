using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebAPI.Models
{
    public class College
    {
        [Key]
        [Column("colz_id",Order=0)]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        public long PhoneNo { get; set; }
    }
}
