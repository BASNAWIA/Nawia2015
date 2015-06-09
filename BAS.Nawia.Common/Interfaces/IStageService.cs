using BAS.Nawia.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Common.Interfaces
{
    public interface IStageService
    {
        ICollection<StageModel> GetAll();
        StageModel Get(int _id);
        void InsertStage(StageModel Stage);
        void UpdateStage(StageModel Stage);
        ICollection<StageModel> GetStageByStatus(StageStatus Status);
        void ChangeStageStatus(int _id, StageStatus Status);
        void Delete(int _id);
    }
}
