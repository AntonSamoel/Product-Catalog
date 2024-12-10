

using System.Text.Json.Serialization;

namespace ProductCatalog.Core.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(75)]
        public string Name { get; set; }

        [JsonIgnore] // To prevent cycling while getting product and category together
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
