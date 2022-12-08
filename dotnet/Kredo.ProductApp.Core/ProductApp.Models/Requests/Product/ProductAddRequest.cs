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
        [StringLength(250, MinimumLength = 2)]
        public string name { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        [StringLength(1500, MinimumLength = 2)]
        public string description { get; set; }

        [Required]
        public int category_id { get; set; }
    }
}
