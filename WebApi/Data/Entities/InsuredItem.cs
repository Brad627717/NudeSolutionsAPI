using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entities
{
    public class InsuredItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string ItemName { get; set; } = string.Empty;

        [Required]
        public double Value { get; set; }

        [Required]
        [ForeignKey("Catagories")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
