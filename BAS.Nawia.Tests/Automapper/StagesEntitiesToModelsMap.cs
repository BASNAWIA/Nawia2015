using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Tests.Automapper
{
    public static class StagesEntitiesToModelsMap
    {
        public static void CreateMap()
        {
            Mapper.CreateMap<DAL.Entities.Stage, Common.Models.StageModel>();
        }
    }
}
