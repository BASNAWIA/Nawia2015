using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Common.Models
{
    public enum SubjectStatus { Approved, Submitted }
    public class SubjectModel
    {
        public int SubjectId { get; set; }
        public string OwnerId { get; set; }
        public bool isVisible { get; set; }
        public DateTime CreationDate { get; set; }
        public SubjectStatus Status { get; set; }
        public string Title { get; set; }
        public string TitlePL { get; set; }
        public string Description { get; set; }
        public string DescriptionPL { get; set; }
        public List<string> Scope { get; set; }
        public List<string> ScopePL { get; set; }
        public string Tags { get; set; }
        public string TagsPL { get; set; }
    }
}
