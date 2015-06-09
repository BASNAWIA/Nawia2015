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
    public class ThesisService : BaseService, IThesisService
    {
        private IUnitOfWork unitOfWork = null;
        private IUserService uService;
        private IStageService sService;
        private ISubjectService sbjService;

        public ThesisService(IUnitOfWork uow, IUserService uservice, ISubjectService sbjservice, IStageService sservice) : base(uow)
        {
            this.unitOfWork = uow;
            uService = uservice;
            sService = sservice;
            sbjService = sbjservice;
        }

        public ICollection<Common.Models.ThesisModel> GetAll()
        {
            var thesisrepo = unitOfWork.Repository<Thesis>();
            var theses = thesisrepo.Queryable().ToList();
            var thesesreturn = new List<ThesisModel>();
            for (int i = 0; i < theses.Count; i++)
            {
                ThesisModel thesismodel = new ThesisModel { ThesisId = theses[i].ThesisId, isVisible = theses[i].isVisible, Status = (Common.Models.ThesisStatus)theses[i].Status, Type = (Common.Models.ThesisType)theses[i].Type };
                thesesreturn.Add(thesismodel);
                if (theses[i].Studentid != null)
                {
                    thesesreturn[i].Student = uService.Get(theses[i].Studentid);
                }
                thesesreturn[i].Supervisor = uService.Get(theses[i].SupervisorId);
                thesesreturn[i].Subject = sbjService.Get(theses[i].SubjectId);
                thesesreturn[i].Stage = sService.Get(theses[i].StageId);
            }
            return thesesreturn;
        }

        public Common.Models.ThesisModel Get(int _id)
        {
            var thesisrepo = unitOfWork.Repository<Thesis>();
            var thesisquery = thesisrepo.Queryable().Where(thesisid => thesisid.ThesisId == _id);
            if (thesisquery == null)
                throw new ArgumentException("Thesis not found");
            var thesis = thesisquery.FirstOrDefault();
            ThesisModel thesismodel = new ThesisModel { ThesisId = thesis.ThesisId, isVisible = thesis.isVisible, Status = (Common.Models.ThesisStatus)thesis.Status, Type = (Common.Models.ThesisType)thesis.Type };
            thesismodel.Student = uService.Get(thesis.Studentid);
            thesismodel.Supervisor = uService.Get(thesis.SupervisorId);
            thesismodel.Subject = sbjService.Get(thesis.SubjectId);
            thesismodel.Stage = sService.Get(thesis.StageId);
            return thesismodel;
        }

        public void InsertThesis(Common.Models.ThesisModel Thesis)
        {
            var thesisrepo = unitOfWork.Repository<Thesis>();
            var thesistoinsert = new Thesis { SupervisorId = Thesis.Supervisor.Id, SubjectId = Thesis.Subject.SubjectId, StageId = Thesis.Stage.StageID, isVisible = Thesis.isVisible, Status = (DAL.Entities.ThesisStatus)Thesis.Status, Type = (DAL.Entities.ThesisType)Thesis.Type };
            if (Thesis.Student != null)
                thesistoinsert.Studentid = Thesis.Student.Id;
            base.Transaction(() =>
            {
                thesisrepo.Insert(thesistoinsert);
            });
            Thesis.ThesisId = thesistoinsert.ThesisId;
        }

        public void UpdateThesis(Common.Models.ThesisModel Thesis)
        {
            var thesisrepo = unitOfWork.Repository<Thesis>();
            var thesisquery = thesisrepo.Queryable().Where(thesisid => thesisid.ThesisId == Thesis.ThesisId);
            if (thesisquery == null)
                throw new ArgumentException("Thesis not found");
            Thesis thesistoupdate = thesisquery.FirstOrDefault();
            thesistoupdate.ThesisId = Thesis.ThesisId;
            thesistoupdate.Studentid = Thesis.Student.Id;
            thesistoupdate.SupervisorId = Thesis.Supervisor.Id;
            thesistoupdate.SubjectId = Thesis.Subject.SubjectId;
            thesistoupdate.StageId = Thesis.Stage.StageID;
            thesistoupdate.isVisible = Thesis.isVisible;
            thesistoupdate.Status = (DAL.Entities.ThesisStatus)Thesis.Status;
            thesistoupdate.Type = (DAL.Entities.ThesisType)Thesis.Type;
            base.Transaction(() =>
            {
                thesisrepo.Update(thesistoupdate);
            });
        }

        public ICollection<Common.Models.ThesisModel> GetThesisByStatus(Common.Models.ThesisStatus Status)
        {
            var thesisrepo = unitOfWork.Repository<Thesis>();
            var theses = thesisrepo.Queryable().Where(thesis => thesis.Status == (DAL.Entities.ThesisStatus)Status).ToList();
            var thesesreturn = new List<ThesisModel>();
            for (int i = 0; i < theses.Count; i++)
            {
                ThesisModel thesismodel = new ThesisModel { ThesisId = theses[i].ThesisId, isVisible = theses[i].isVisible, Status = (Common.Models.ThesisStatus)theses[i].Status, Type = (Common.Models.ThesisType)theses[i].Type };
                thesesreturn.Add(thesismodel);
                if (theses[i].Studentid != null)
                {
                    thesesreturn[i].Student = uService.Get(theses[i].Studentid);
                }
                thesesreturn[i].Supervisor = uService.Get(theses[i].SupervisorId);
                thesesreturn[i].Subject = sbjService.Get(theses[i].SubjectId);
                thesesreturn[i].Stage = sService.Get(theses[i].StageId);
            }
            return thesesreturn;
        }

        public ICollection<Common.Models.ThesisModel> GetThesisByType(Common.Models.ThesisType Type)
        {
            var thesisrepo = unitOfWork.Repository<Thesis>();
            var theses = thesisrepo.Queryable().Where(thesis => thesis.Type == (DAL.Entities.ThesisType)Type).ToList();
            var thesesreturn = new List<ThesisModel>();
            for (int i = 0; i < theses.Count; i++)
            {
                ThesisModel thesismodel = new ThesisModel { ThesisId = theses[i].ThesisId, isVisible = theses[i].isVisible, Status = (Common.Models.ThesisStatus)theses[i].Status, Type = (Common.Models.ThesisType)theses[i].Type };
                thesesreturn.Add(thesismodel);
                if (theses[i].Studentid != null)
                {
                    thesesreturn[i].Student = uService.Get(theses[i].Studentid);
                }
                thesesreturn[i].Supervisor = uService.Get(theses[i].SupervisorId);
                thesesreturn[i].Subject = sbjService.Get(theses[i].SubjectId);
                thesesreturn[i].Stage = sService.Get(theses[i].StageId);
            }
            return thesesreturn;
        }

        public void Delete(int _id)
        {
            var thesisrepo = unitOfWork.Repository<Thesis>();
            base.Transaction(() =>
            {
                thesisrepo.Delete(_id);
            });
        }


        public ICollection<ThesisModel> GetThesisByStudent(string _userid)
        {
            var thesisrepo = unitOfWork.Repository<Thesis>();
            var theses = thesisrepo.Queryable().Where(thesis => thesis.Studentid == _userid).ToList();
            var thesesreturn = new List<ThesisModel>();
            for (int i = 0; i < theses.Count; i++)
            {
                ThesisModel thesismodel = new ThesisModel { ThesisId = theses[i].ThesisId, isVisible = theses[i].isVisible, Status = (Common.Models.ThesisStatus)theses[i].Status, Type = (Common.Models.ThesisType)theses[i].Type };
                thesesreturn.Add(thesismodel);
                if (theses[i].Studentid != null)
                {
                    thesesreturn[i].Student = uService.Get(theses[i].Studentid);
                }
                thesesreturn[i].Supervisor = uService.Get(theses[i].SupervisorId);
                thesesreturn[i].Subject = sbjService.Get(theses[i].SubjectId);
                thesesreturn[i].Stage = sService.Get(theses[i].StageId);
            }
            return thesesreturn;
        }


        public ICollection<ThesisModel> GetThesisBySupervisor(string _userid)
        {
            var thesisrepo = unitOfWork.Repository<Thesis>();
            var theses = thesisrepo.Queryable().Where(thesis => thesis.SupervisorId == _userid).ToList();
            var thesesreturn = new List<ThesisModel>();
            for (int i = 0; i < theses.Count; i++)
            {
                ThesisModel thesismodel = new ThesisModel { ThesisId = theses[i].ThesisId, isVisible = theses[i].isVisible, Status = (Common.Models.ThesisStatus)theses[i].Status, Type = (Common.Models.ThesisType)theses[i].Type };
                thesesreturn.Add(thesismodel);
                if (theses[i].Studentid != null)
                {
                    thesesreturn[i].Student = uService.Get(theses[i].Studentid);
                }
                thesesreturn[i].Supervisor = uService.Get(theses[i].SupervisorId);
                thesesreturn[i].Subject = sbjService.Get(theses[i].SubjectId);
                thesesreturn[i].Stage = sService.Get(theses[i].StageId);
            }
            return thesesreturn;
        }
    }
}
