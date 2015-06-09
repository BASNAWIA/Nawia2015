using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootstrap;
using Bootstrap.Unity;
using Bootstrap.AutoMapper;
using Microsoft.Practices.Unity;
using System.Reflection;

namespace BAS.Nawia.Tests
{
    public static class IoC
    {
        public static void InitializeIoC()
        {
            Bootstrapper.With.Unity().And.AutoMapper().Excluding.Assembly("BAS.Nawia.Web").Start();
        }

        public static void DisposeIoC()
        {
            var container = (IUnityContainer)Bootstrapper.Container;
            container.Dispose();
            Bootstrapper.Reset();
        }
    }
}
