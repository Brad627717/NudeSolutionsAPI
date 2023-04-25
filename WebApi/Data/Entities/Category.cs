using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; } = string.Empty;

        public List<InsuredItem> InsuredItems { get; set; }
    }
}
