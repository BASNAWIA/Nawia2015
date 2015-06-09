using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAS.Nawia.Web.Automapper
{
    public static class SubjectEntitiesToModelsMaps
    {
        public static void CreateMap()
        {
            Mapper.CreateMap<DAL.Entities.Subject, Common.Models.SubjectModel>();
        }
    }
}