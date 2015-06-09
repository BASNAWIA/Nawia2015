using BAS.Nawia.Common.Interfaces;
using BAS.Nawia.Common.Models;
using Bootstrap;
using KellermanSoftware.CompareNetObjects;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BAS.Nawia.Tests
{
    public class ThesisServiceTests : IClassFixture<TestsFixture>
    {
        IThesisService tService;
        IStageService sService;
        ISubjectService sbjService;
        IUserService uService;
        private CompareLogic basicComparison = new CompareLogic() { Config = new ComparisonConfig() };

        public ThesisServiceTests()
        {
            var container = (IUnityContainer)Bootstrapper.Container;
            tService = container.Resolve<IThesisService>();
            sService = container.Resolve<IStageService>();
            sbjService = container.Resolve<ISubjectService>();
            uService = container.Resolve<IUserService>();
        }

        [Fact]
        public void InsertTest()
        {
            var supervisor = new UserModel { Id = "f8aff666-e0c6-4a5f-a6c9-527e5b710e23" };
            var subject = new SubjectModel { isVisible = true, Tags = "aaaaa, bbbbb", Title = "abcd", TitlePL = "ABCD", CreationDate = DateTime.Now, SubjectId = -1 };
            var stage = new StageModel { DateStart = DateTime.Now, DateEnd = DateTime.Now.AddHours(6), Status = StageStatus.Open, Name = "2014/2015", StageID = -2 };
            var thesistoinsert = new ThesisModel { Student = null, Supervisor = supervisor, Subject = subject, Stage = stage, isVisible = true, Status = ThesisStatus.Open, Type = ThesisType.Bachelor };
            tService.InsertThesis(thesistoinsert);
            var thesisid = thesistoinsert.ThesisId;
            tService.Delete(thesisid);
            Assert.NotNull(thesisid);
        }

        [Fact]
        public void UpdateTest()
        {
            var supervisor = uService.GetByUsername("admin");
            var subject = new SubjectModel { isVisible = true, Tags = "aaaaa, bbbbb", Title = "abcd", TitlePL = "ABCD", CreationDate = new DateTime(2015, 11, 1), Scope = new List<string>(), ScopePL = new List<string>() };
            sbjService.InsertSubject(subject);
            var stage = new StageModel { DateStart = new DateTime(2015, 11, 1), DateEnd = new DateTime(2015, 11, 1).AddMonths(1), Status = StageStatus.Open, Name = "2014/2015" };
            sService.InsertStage(stage);
            var thesistoinsert = new ThesisModel { Student = null, Supervisor = supervisor, Subject = subject, Stage = stage, isVisible = true, Status = ThesisStatus.Open, Type = ThesisType.Bachelor };
            tService.InsertThesis(thesistoinsert);
            var thesisid = thesistoinsert.ThesisId;
            var updatedthesis = thesistoinsert;
            updatedthesis.Status = ThesisStatus.Assigned;
            var student = uService.GetByUsername("teststudent");
            updatedthesis.Student = student;
            tService.UpdateThesis(updatedthesis);
            var thesisfromdatabase = tService.Get(thesisid);
            sbjService.Delete(subject.SubjectId);
            sService.Delete(stage.StageID);
            tService.Delete(thesisid);
            var equals = basicComparison.Compare(updatedthesis, thesisfromdatabase).AreEqual;
            Assert.True(equals);
        }

        [Fact]
        public void GetTest()
        {
            var supervisor = uService.GetByUsername("admin");
            var subject = new SubjectModel { isVisible = true, Tags = "aaaaa, bbbbb", Title = "abcd", TitlePL = "ABCD", CreationDate = new DateTime(2015, 11, 1), Scope = new List<string>(), ScopePL = new List<string>() };
            sbjService.InsertSubject(subject);
            var stage = new StageModel { DateStart = new DateTime(2015, 11, 1), DateEnd = new DateTime(2015, 11, 1).AddMonths(1), Status = StageStatus.Open, Name = "2014/2015" };
            sService.InsertStage(stage);
            var thesistoinsert = new ThesisModel { Student = null, Supervisor = supervisor, Subject = subject, Stage = stage, isVisible = true, Status = ThesisStatus.Open, Type = ThesisType.Bachelor };
            tService.InsertThesis(thesistoinsert);
            var thesisid = thesistoinsert.ThesisId;
            var thesisfromdatabase = tService.Get(thesisid);
            sbjService.Delete(subject.SubjectId);
            sService.Delete(stage.StageID);
            tService.Delete(thesisid);
            var equals = basicComparison.Compare(thesistoinsert, thesisfromdatabase).AreEqual;
            Assert.True(equals);
        }

        [Fact]
        public void DeleteTest()
        {
            var supervisor = uService.GetByUsername("admin");
            var subject = new SubjectModel { isVisible = true, Tags = "aaaaa, bbbbb", Title = "abcd", TitlePL = "ABCD", CreationDate = DateTime.Now, SubjectId = -1 };
            sbjService.InsertSubject(subject);
            var stage = new StageModel { DateStart = DateTime.Now, DateEnd = DateTime.Now.AddHours(6), Status = StageStatus.Open, Name = "2014/2015", StageID = -2 };
            sService.InsertStage(stage);
            var thesistoinsert = new ThesisModel { Student = null, Supervisor = supervisor, Subject = subject, Stage = stage, isVisible = true, Status = ThesisStatus.Open, Type = ThesisType.Bachelor };
            tService.InsertThesis(thesistoinsert);
            var thesisid = thesistoinsert.ThesisId;
            int amountoftheses = tService.GetAll().Count;
            sbjService.Delete(subject.SubjectId);
            sService.Delete(stage.StageID);
            tService.Delete(thesisid);
            int amountafterdelete = tService.GetAll().Count;
            Assert.Equal(amountoftheses - 1, amountafterdelete);
        }
    }
}
