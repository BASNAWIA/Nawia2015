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
    public class StageServiceTests : IClassFixture<TestsFixture>
    {
        IStageService sService;
        private CompareLogic basicComparison = new CompareLogic() { Config = new ComparisonConfig() };

        public StageServiceTests()
        {
            var container = (IUnityContainer)Bootstrapper.Container;
            sService = container.Resolve<IStageService>();
        }

        [Fact]
        public void InsertTest()
        {
            var stagetoinsert = new StageModel { DateStart = DateTime.Now, DateEnd = DateTime.Now.AddHours(6), Status = StageStatus.Open, Name = "2014/2015" };
            sService.InsertStage(stagetoinsert);
            var stageid = stagetoinsert.StageID;
            sService.Delete(stageid);
            Assert.NotNull(stageid);
        }

        [Fact]
        public void UpdateTest()
        {
            var stagetoinsert = new StageModel { DateStart = DateTime.Now, DateEnd = DateTime.Now.AddHours(6), Status = StageStatus.Open, Name = "2014/2015" };
            sService.InsertStage(stagetoinsert);
            var stageid = stagetoinsert.StageID;
            var updatedstage = stagetoinsert;
            updatedstage.Name = "2015/2016";
            updatedstage.DateStart = DateTime.Now.AddHours(2);
            updatedstage.DateEnd = DateTime.Now.AddHours(14);
            updatedstage.Status = StageStatus.Closed;
            sService.UpdateStage(updatedstage);
            var stagefromdatabase = sService.Get(stageid);
            sService.Delete(stageid);
            var equals = basicComparison.Compare(updatedstage, stagefromdatabase).AreEqual;
            Assert.True(equals);
        }

        [Fact]
        public void ChangeStatusTest()
        {
            var stagetoinsert = new StageModel { DateStart = DateTime.Now, DateEnd = DateTime.Now.AddHours(6), Status = StageStatus.Open, Name = "2014/2015" };
            sService.InsertStage(stagetoinsert);
            var stageid = stagetoinsert.StageID;
            var updatedstage = stagetoinsert;
            updatedstage.Status = StageStatus.Closed;
            sService.ChangeStageStatus(stageid, StageStatus.Closed);
            var stagefromdatabase = sService.Get(stageid);
            sService.Delete(stageid);
            var equals = basicComparison.Compare(updatedstage, stagefromdatabase).AreEqual;
            Assert.True(equals);
        }

        [Fact]
        public void GetTest()
        {
            var stagetoinsert = new StageModel { DateStart = DateTime.Now, DateEnd = DateTime.Now.AddHours(6), Status = StageStatus.Open, Name = "2014/2015" };
            sService.InsertStage(stagetoinsert);
            var stageid = stagetoinsert.StageID;
            var stagefromdatabase = sService.Get(stageid);
            sService.Delete(stageid);
            var equals = basicComparison.Compare(stagetoinsert, stagefromdatabase).AreEqual;
            Assert.True(equals);
        }

        [Fact]
        public void DeleteTest()
        {
            var stagetoinsert = new StageModel { DateStart = DateTime.Now, DateEnd = DateTime.Now.AddHours(6), Status = StageStatus.Open, Name = "2014/2015" };
            sService.InsertStage(stagetoinsert);
            var stageid = stagetoinsert.StageID;
            var stagefromdatabase = sService.Get(stageid);
            int amountofstages = sService.GetAll().Count;
            sService.Delete(stageid);
            int amountafterdelete = sService.GetAll().Count;
            Assert.Equal(amountofstages - 1, amountafterdelete);
        }
    }
}
