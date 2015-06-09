using BAS.Nawia.DAL;
using BAS.Nawia.DAL.Entities;
using Bootstrap.Unity;
using Microsoft.Practices.Unity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAS.Nawia.Web.Installers
{
    public class DALInstaller : IUnityRegistration
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IDataContextAsync, DatabaseContext>(new PerRequestLifetimeManager())
                .RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager())
                .RegisterType<IRepository<Subject>, Repository<Subject>>();
        }
    }
}