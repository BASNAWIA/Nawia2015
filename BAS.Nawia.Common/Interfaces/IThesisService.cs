using BAS.Nawia.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Common.Interfaces
{
    public interface IThesisService
    {
        ICollection<ThesisModel> GetAll();
        ThesisModel Get(int _id);
        ICollection<ThesisModel> GetThesisByStudent(string _userid);
        ICollection<ThesisModel> GetThesisBySupervisor(string _userid);
        void InsertThesis(ThesisModel Thesis);
        void UpdateThesis(ThesisModel Thesis);
        ICollection<ThesisModel> GetThesisByStatus(ThesisStatus Status);
        ICollection<ThesisModel> GetThesisByType(ThesisType Type);
        void Delete(int _id);
    }
}
