using BAS.Nawia.Common.Interfaces;
using BAS.Nawia.Common.Models;
using BAS.Nawia.Services;
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
    public class SubjectServiceTests : IClassFixture<TestsFixture>
    {
        ISubjectService sService;
        private CompareLogic basicComparison = new CompareLogic() { Config = new ComparisonConfig() };

        public SubjectServiceTests()
        {
            var container = (IUnityContainer)Bootstrapper.Container;
            sService = container.Resolve<ISubjectService>();
        }

        [Fact]
        public void InsertTest()
        {
            List<string> scopes = new List<string>();
            scopes.Add("abcd");
            scopes.Add("1234");
            var subjecttoinsert = new SubjectModel { isVisible = true, Tags = "aaaaa, bbbbb", Title = "abcd", TitlePL = "ABCD", Scope = scopes, ScopePL = scopes, CreationDate = DateTime.Now };
            sService.InsertSubject(subjecttoinsert);
            var subjectid = subjecttoinsert.SubjectId;
            sService.Delete(subjectid);
            Assert.NotNull(subjectid);
        }

        [Fact]
        public void UpdateTest()
        {
            List<string> scopes = new List<string>();
            scopes.Add("abcd");
            scopes.Add("1234");
            var subjecttoinsert = new SubjectModel { isVisible = true, Tags = "aaaaa, bbbbb", Title = "abcd", TitlePL = "ABCD", Scope = scopes, ScopePL = scopes, CreationDate = DateTime.Now };
            sService.InsertSubject(subjecttoinsert);
            var subjectid = subjecttoinsert.SubjectId;
            var updatedsubject = subjecttoinsert;
            updatedsubject.Title = "UPDATED";
            scopes.Add("defg");
            scopes[0] = "rfvg";
            scopes.Remove("1234");
            scopes.Add("dddds");
            updatedsubject.Scope = scopes;
            updatedsubject.ScopePL = scopes;
            sService.UpdateSubject(updatedsubject);
            var subjectfromdatabase = sService.Get(subjectid);
            sService.Delete(subjectid);
            var equals = basicComparison.Compare(updatedsubject, subjectfromdatabase).AreEqual;
            Assert.True(equals);
        }

        [Fact]
        public void GetTest()
        {
            List<string> scopes = new List<string>();
            scopes.Add("abcd");
            scopes.Add("1234");
            var subjecttoinsert = new SubjectModel { isVisible = true, Tags = "aaaaa, bbbbb", Title = "abcd", TitlePL = "ABCD", Scope = scopes, ScopePL = scopes, CreationDate = DateTime.Now };
            sService.InsertSubject(subjecttoinsert);
            var subjectid = subjecttoinsert.SubjectId;
            var subjectfromdatabase = sService.Get(subjectid);
            sService.Delete(subjectid);
            var equals = basicComparison.Compare(subjecttoinsert, subjectfromdatabase).AreEqual;
            Assert.True(equals);
        }

        [Fact]
        public void DeleteTest()
        {
            List<string> scopes = new List<string>();
            scopes.Add("abcd");
            scopes.Add("1234");
            var subjecttoinsert = new SubjectModel { isVisible = true, Tags = "aaaaa, bbbbb", Title = "abcd", TitlePL = "ABCD", Scope = scopes, ScopePL = scopes, CreationDate = DateTime.Now };
            sService.InsertSubject(subjecttoinsert);
            var subjectid = subjecttoinsert.SubjectId;
            int amountofsubjects = sService.GetAll().Count;
            sService.Delete(subjectid);
            int amountafterdelete = sService.GetAll().Count;
            Assert.Equal(amountofsubjects - 1, amountafterdelete);
        }
    }
}
