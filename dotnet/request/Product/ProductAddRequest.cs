using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Models.Requests.Product
{
    public class ProductAddRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Make { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(1500, MinimumLength = 2)]
        public string Description { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 2)]
        public string ImageUrl { get; set; }
    }
}
