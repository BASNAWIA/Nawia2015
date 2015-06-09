using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.DAL.Entities
{
    public class SubjectScope : Entity
    {
        [Key]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string Scope { get; set; }
        public string ScopePL { get; set; }
    }
}
