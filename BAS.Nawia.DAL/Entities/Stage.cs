using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.DAL.Entities
{
    public enum StageStatus { Open, Closed }
    public class Stage : Entity
    {
        [Key]
        public int StageID { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public StageStatus Status { get; set; }
        public string Name { get; set; }
    }
}
