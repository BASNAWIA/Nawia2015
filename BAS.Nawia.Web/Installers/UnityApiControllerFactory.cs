using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace BAS.Nawia.Web.Installers
{
    public class UnityApiControllerFactory : IHttpControllerActivator
    {
        private readonly IUnityContainer _container;

        public UnityApiControllerFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType == null) return null;
            var constructor = controllerType.GetConstructors().FirstOrDefault();
            var parms = new List<object>();
            foreach (var p in constructor.GetParameters())
            {
                Type temp = p.ParameterType;
                object obj = _container.Resolve(temp);
                parms.Add(obj);
            }
            return (IHttpController)Activator.CreateInstance(controllerType, parms.ToArray());
        }
    }
}