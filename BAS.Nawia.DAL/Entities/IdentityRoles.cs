using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.DAL.Entities
{
    public class IdentityRoles : Entity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
