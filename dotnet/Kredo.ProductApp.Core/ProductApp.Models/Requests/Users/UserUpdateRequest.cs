using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Models.Requests.Users
{
    public class UserUpdateRequest : UserAddRequest, IModelIdentifier
    {
        public int Id { get; set; }
    }
}
