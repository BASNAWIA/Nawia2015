using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.DAL.Entities
{
    public class IdentityLogin : Entity
    {
        [Key, Column(Order = 0)]
        public string LoginProvider { get; set; }
        [Key, Column(Order = 1)]
        public string ProviderKey { get; set; }
        [Key, Column(Order = 2)]
        public string UserId { get; set; }
    }
}
