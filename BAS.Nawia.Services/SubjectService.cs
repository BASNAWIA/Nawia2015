using AutoMapper;
using BAS.Nawia.Common.Interfaces;
using BAS.Nawia.Common.Models;
using BAS.Nawia.DAL.Entities;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Services
{
    public class SubjectService : BaseService, ISubjectService
    {
        private IUnitOfWork unitOfWork = null;

        public SubjectService(IUnitOfWork uow) : base(uow)
        {
            this.unitOfWork = uow;
        }

        public ICollection<Common.Models.SubjectModel> GetAll()
        {
            var subjectrepo = unitOfWork.Repository<Subject>();
            var subjects = subjectrepo.Queryable().ToList();
            var subjectsreturn = Mapper.Map<ICollection<Subject>, ICollection<SubjectModel>>(subjects);
            var subjectscoperepo = unitOfWork.Repository<SubjectScope>();
            foreach(var i in subjectsreturn)
            {
                var subjectscopes = subjectscoperepo.Queryable().Where(subjectscope => subjectscope.SubjectId == i.SubjectId).ToList();
                i.Scope = new List<string>();
                i.ScopePL = new List<string>();
                foreach (var j in subjectscopes)
                {
                    i.Scope.Add(j.Scope);
                    i.ScopePL.Add(j.ScopePL);
                }
            }
            return subjectsreturn;
        }

        public Common.Models.SubjectModel Get(int _id)
        {
            var subjectrepo = unitOfWork.Repository<Subject>();
            var subject = subjectrepo.Queryable().Where(subjectid => subjectid.SubjectId == _id);
            if (subject == null)
                throw new ArgumentException("Subject not found");
            SubjectModel subjectmodel = Mapper.Map<Subject, SubjectModel>(subject.FirstOrDefault());
            var subjectscoperepo = unitOfWork.Repository<SubjectScope>();
            var subjectscopes = subjectscoperepo.Queryable().Where(subjectscope => subjectscope.SubjectId == subjectmodel.SubjectId).ToList();
            subjectmodel.Scope = new List<string>();
            subjectmodel.ScopePL = new List<string>();
            foreach (var j in subjectscopes)
            {
                subjectmodel.Scope.Add(j.Scope);
                subjectmodel.ScopePL.Add(j.ScopePL);
            }
            return subjectmodel;
        }

        public int InsertSubject(Common.Models.SubjectModel Subject)
        {
            var subjectrepo = unitOfWork.Repository<Subject>();
            var subjecttoinsert = new Subject {OwnerId = Subject.OwnerId, isVisible = Subject.isVisible, CreationDate = Subject.CreationDate, Status = (BAS.Nawia.DAL.Entities.SubjectStatus)Subject.Status, Title = Subject.Title, TitlePL = Subject.TitlePL, Description = Subject.Description, DescriptionPL = Subject.DescriptionPL, Tags = Subject.Tags, TagsPL = Subject.TagsPL};
            var subjectscoperepo = unitOfWork.Repository<SubjectScope>();
            List<SubjectScope> subjectscopestoinsert = new List<SubjectScope>();
            base.Transaction(() =>
            {
                subjectrepo.Insert(subjecttoinsert);
            });
            Subject.SubjectId = subjecttoinsert.SubjectId;
            if (Subject.Scope != null)
            {
                for (int i = 0; i < Subject.Scope.Count; i++)
                {
                    subjectscopestoinsert.Add(new SubjectScope { SubjectId = subjecttoinsert.SubjectId, Scope = Subject.Scope[i], ScopePL = Subject.ScopePL[i] });
                }
                base.Transaction(() =>
                {
                    foreach (var i in subjectscopestoinsert)
                    {
                        subjectscoperepo.Insert(i);
                    }
                });
            }
            return Subject.SubjectId;
        }

        public void UpdateSubject(Common.Models.SubjectModel Subject)
        {
            var subjectrepo = unitOfWork.Repository<Subject>();
            var subjectquery = subjectrepo.Queryable().Where(subjectid => subjectid.SubjectId == Subject.SubjectId);
            if (subjectquery == null)
                throw new ArgumentException("Subject not found");
            Subject subjecttoupdate = subjectquery.FirstOrDefault();
            subjecttoupdate.OwnerId = Subject.OwnerId;
            subjecttoupdate.isVisible = Subject.isVisible;
            subjecttoupdate.CreationDate = Subject.CreationDate;
            subjecttoupdate.Status = (DAL.Entities.SubjectStatus)Subject.Status;
            subjecttoupdate.Title = Subject.Title;
            subjecttoupdate.TitlePL = Subject.TitlePL;
            subjecttoupdate.Description = Subject.Description;
            subjecttoupdate.DescriptionPL = Subject.DescriptionPL;
            subjecttoupdate.Tags = Subject.Tags;
            subjecttoupdate.TagsPL = Subject.TagsPL;
            List<SubjectScope> subjectscopestoinsert = new List<SubjectScope>();
            for (int i = 0; i < Subject.Scope.Count; i++)
            {
                subjectscopestoinsert.Add(new SubjectScope { SubjectId = Subject.SubjectId, Scope = Subject.Scope[i], ScopePL = Subject.ScopePL[i] });
            }
            var subjectscoperepo = unitOfWork.Repository<SubjectScope>();
            var subjectscopes = subjectscoperepo.Queryable().Where(subjectscope => subjectscope.SubjectId == Subject.SubjectId).ToList();
            base.Transaction(() =>
            {
                subjectrepo.Update(subjecttoupdate);
                foreach (var i in subjectscopes)
                {
                    subjectscoperepo.Delete(i.Id);
                }
                foreach (var i in subjectscopestoinsert)
                {
                    subjectscoperepo.Insert(i);
                }
            });
        }

        public ICollection<Common.Models.SubjectModel> GetSubjectByStatus(Common.Models.SubjectStatus Status)
        {
            var subjectrepo = unitOfWork.Repository<Subject>();
            var subjects = subjectrepo.Queryable().Where(subject => subject.Status == (DAL.Entities.SubjectStatus)Status).ToList();
            var subjectsreturn = Mapper.Map<ICollection<Subject>, ICollection<SubjectModel>>(subjects);
            var subjectscoperepo = unitOfWork.Repository<SubjectScope>();
            foreach (var i in subjectsreturn)
            {
                var subjectscopes = subjectscoperepo.Queryable().Where(subjectscope => subjectscope.Id == i.SubjectId).ToList();
                i.Scope = new List<string>();
                i.ScopePL = new List<string>();
                foreach (var j in subjectscopes)
                {
                    i.Scope.Add(j.Scope);
                    i.ScopePL.Add(j.ScopePL);
                }
            }
            return subjectsreturn;
        }

        public void Delete(int _id)
        {
            var subjectrepo = unitOfWork.Repository<Subject>();
            var subjectscoperepo = unitOfWork.Repository<SubjectScope>();
            var subjectscopes = subjectscoperepo.Queryable().Where(subjectscope => subjectscope.SubjectId == _id).ToList();
            base.Transaction(() =>
            {
                subjectrepo.Delete(_id);
                foreach(var i in subjectscopes)
                {
                    subjectscoperepo.Delete(i.Id);
                }
            });
        }
    }
}
