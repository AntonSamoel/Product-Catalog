using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Core.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        //[Required] // Will get it using identity 
        //public string UserId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int DurationInDays { get; set; }
        [Required]
        public double Price { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        
    }
}
