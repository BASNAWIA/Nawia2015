using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Common.Models
{
    public enum ThesisStatus { Open, Archived, Assigned, Locked }
    public enum ThesisType { Bachelor, Master, PhD }
    public class ThesisModel
    {
        public int ThesisId { get; set; }
        public UserModel Student { get; set; }
        public string StudentID { get; set; }
        public UserModel Supervisor { get; set; }
        public string SupervisorID { get; set; }
        public SubjectModel Subject { get; set; }
        public int SubjectID { get; set; }
        public StageModel Stage { get; set; }
        public int StageID { get; set; }
        public bool isVisible { get; set; }
        public ThesisStatus Status { get; set; }
        public ThesisType Type { get; set; }
    }
}
