using BAS.Nawia.Common.Interfaces;
using BAS.Nawia.DAL;
using BAS.Nawia.DAL.Entities;
using BAS.Nawia.Services;
using Bootstrap.Unity;
using Microsoft.Practices.Unity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Tests
{
    public class Installers : IUnityRegistration
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IDataContextAsync, DatabaseContext>()
                .RegisterType<IUnitOfWork, UnitOfWork>()
                .RegisterType<IRepository<Subject>, Repository<Subject>>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ISubjectService, SubjectService>();
            container.RegisterType<IStageService, StageService>();
            container.RegisterType<IThesisService, ThesisService>();
        }
    }
}
