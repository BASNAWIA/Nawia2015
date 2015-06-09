using BAS.Nawia.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Common.Interfaces
{
    public interface ISubjectService
    {
        ICollection<SubjectModel> GetAll();
        SubjectModel Get(int _id);
        int InsertSubject(SubjectModel Subject);
        void UpdateSubject(SubjectModel Subject);
        ICollection<SubjectModel> GetSubjectByStatus(SubjectStatus Status);
        void Delete(int _id);
    }
}
