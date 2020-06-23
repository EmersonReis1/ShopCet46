using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCet46.Web.Data.Entities
{
    public class User : IdentityUser
    {
        public string FristName { get; set; }

        public string LastName { get; set; }
    }
}
