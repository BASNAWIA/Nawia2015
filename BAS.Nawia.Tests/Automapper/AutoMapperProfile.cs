using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Tests.Automapper
{
    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.Configuration.AllowNullCollections = true;
            SubjectEntitiesToModelsMaps.CreateMap();
            StagesEntitiesToModelsMap.CreateMap();
            UserEntitiesToModelsMap.CreateMap();
        }
    }
}
