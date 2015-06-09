using BAS.Nawia.Common.Interfaces;
using BAS.Nawia.Services;
using Bootstrap.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAS.Nawia.Web.Installers
{
    public class ServicesInstaller : IUnityRegistration
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ISubjectService, SubjectService>();
            container.RegisterType<IStageService, StageService>();
            container.RegisterType<IThesisService, ThesisService>();
        }    
    }
}