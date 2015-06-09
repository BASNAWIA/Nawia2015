using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Common.Models
{
    public class UserModel : IdentityUser
    {
        public override string Id { get; set; }
        public override string UserName { get; set; }
        public override string Email { get; set; }
        public override bool EmailConfirmed { get; set; }
        public bool IsConfirmed { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }
}
