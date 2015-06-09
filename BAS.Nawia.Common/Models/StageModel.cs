using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Common.Models
{
    public enum StageStatus { Open, Closed }
    public class StageModel
    {
        public int StageID { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public StageStatus Status { get; set; }
        public string Name { get; set; }
    }
}
