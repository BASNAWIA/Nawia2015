using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.DAL.Entities
{
    public enum ThesisStatus { Open, Archived, Assigned, Locked }
    public enum ThesisType { Bachelor, Master, PhD}
    public class Thesis : Entity
    {
        [Key]
        public int ThesisId { get; set; }
        public string Studentid { get; set; }
        public string SupervisorId { get; set; }
        public int SubjectId { get; set; }
        public int StageId { get; set; }
        public bool isVisible { get; set; }
        public ThesisStatus Status { get; set; }
        public ThesisType Type { get; set; }
    }
}
