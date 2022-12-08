using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Models.Requests.Category
{
    public class CategoryAddRequest
    {
        [Required]
        [StringLength(250, MinimumLength = 2)]
        public string name { get; set; }

    }
}
