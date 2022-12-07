using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Models.Requests.Product
{
    public class ProductUpdateRequest : ProductAddRequest , IModelIdentifier
    {
        public int Id { get; set; }
    }
}
