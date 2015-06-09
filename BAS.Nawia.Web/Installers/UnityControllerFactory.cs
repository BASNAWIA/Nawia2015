using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BAS.Nawia.Web.Installers
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        private readonly IUnityContainer _container;

        public UnityControllerFactory(IUnityContainer container)
        {
            _container = container;
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                return (IController)_container.Resolve(GetControllerType(requestContext, controllerName));
            }
            catch
            {
                return base.CreateController(requestContext, controllerName);
            }
        }

        public override void ReleaseController(IController controller)
        {
            _container.Teardown(controller);
            base.ReleaseController(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
           return (IController)_container.Resolve(controllerType);
        }
    }
}