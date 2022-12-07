using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Models.Requests.Category
{
    public class CategoryUpdateRequest : CategoryAddRequest , IModelIdentifier
    {
        public int Id { get; set; }
    }
}
