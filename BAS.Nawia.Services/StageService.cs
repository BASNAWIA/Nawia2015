using AutoMapper;
using BAS.Nawia.Common.Interfaces;
using BAS.Nawia.Common.Models;
using BAS.Nawia.DAL.Entities;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Services
{
    public class StageService : BaseService, IStageService
    {
        private IUnitOfWork unitOfWork = null;

        public StageService(IUnitOfWork uow) : base(uow)
        {
            this.unitOfWork = uow;
        }

        public ICollection<Common.Models.StageModel> GetAll()
        {
            var stagerepo = unitOfWork.Repository<Stage>();
            var stages = stagerepo.Queryable().ToList();
            var stagesreturn = Mapper.Map<ICollection<Stage>, ICollection<StageModel>>(stages);
            return stagesreturn;
        }

        public Common.Models.StageModel Get(int _id)
        {
            var stagerepo = unitOfWork.Repository<Stage>();
            var stage = stagerepo.Queryable().Where(stageid => stageid.StageID == _id);
            if (stage == null)
                throw new ArgumentException("Stage not found");
            StageModel stagemodel = Mapper.Map<Stage, StageModel>(stage.FirstOrDefault());
            return stagemodel;
        }

        public void InsertStage(Common.Models.StageModel Stage)
        {
            var stagerepo = unitOfWork.Repository<Stage>();
            var stagetoinsert = new Stage { DateStart = Stage.DateStart, DateEnd = Stage.DateEnd, Status = (BAS.Nawia.DAL.Entities.StageStatus)Stage.Status, Name = Stage.Name };
            base.Transaction(() =>
            {
                stagerepo.Insert(stagetoinsert);
            });
            Stage.StageID = stagetoinsert.StageID;
        }

        public void UpdateStage(Common.Models.StageModel Stage)
        {
            var stagerepo = unitOfWork.Repository<Stage>();
            var stagequery = stagerepo.Queryable().Where(stageid => stageid.StageID == Stage.StageID);
            if (stagequery == null)
                throw new ArgumentException("Stage not found");
            Stage stagetoupdate = stagequery.FirstOrDefault();
            stagetoupdate.StageID = Stage.StageID;
            stagetoupdate.DateStart = Stage.DateStart;
            stagetoupdate.DateEnd = Stage.DateEnd;
            stagetoupdate.Status = (DAL.Entities.StageStatus)Stage.Status;
            stagetoupdate.Name = Stage.Name;
            base.Transaction(() =>
            {
                stagerepo.Update(stagetoupdate);
            });
        }

        public ICollection<Common.Models.StageModel> GetStageByStatus(Common.Models.StageStatus Status)
        {
            var stagerepo = unitOfWork.Repository<Stage>();
            var stages = stagerepo.Queryable().Where(stage => stage.Status == (DAL.Entities.StageStatus)Status).ToList();
            var stagesreturn = Mapper.Map<ICollection<Stage>, ICollection<StageModel>>(stages);
            return stagesreturn;
        }

        public void ChangeStageStatus(int _id, Common.Models.StageStatus Status)
        {
            var stagerepo = unitOfWork.Repository<Stage>();
            var stagequery = stagerepo.Queryable().Where(stageid => stageid.StageID == _id);
            if (stagequery == null)
                throw new ArgumentException("Stage not found");
            Stage stagetoupdate = stagequery.FirstOrDefault();
            stagetoupdate.Status = (BAS.Nawia.DAL.Entities.StageStatus)Status;
            base.Transaction(() =>
            {
                stagerepo.Update(stagetoupdate);
            });
        }

        public void Delete(int _id)
        {
            var stagerepo = unitOfWork.Repository<Stage>();
            base.Transaction(() =>
            {
                stagerepo.Delete(_id);
            });
        }
    }
}
