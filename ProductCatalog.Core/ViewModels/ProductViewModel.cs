using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ProductCatalog.Core.ViewModels
{
    public class ProductViewModel
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        //[Required] // Will get it using identity 
        //public string UserId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        [Range(1, int.MaxValue,ErrorMessage ="Duration must be from 1 day and above")]
        [Display(Name = "Duration in Days")]
        public int DurationInDays { get; set; }
        [Required]
        [Range(1, 1000000)]
        public double Price { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
