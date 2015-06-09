using Bootstrap;
using Bootstrap.Unity;
using Bootstrap.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using System.Web.Http.Dispatcher;
using BAS.Nawia.Web.Installers;
using Common.Logging;

namespace BAS.Nawia.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        IUnityContainer _container;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.With.Unity().And.AutoMapper().Excluding.Assembly("BAS.Nawia.Tests").LookForTypesIn.ReferencedAssemblies().Start();
            _container = (IUnityContainer)Bootstrapper.Container;
            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory(_container));
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new UnityApiControllerFactory(_container));
        }

        protected void Application_End()
        {
            _container.Dispose();
        }
    }
}
