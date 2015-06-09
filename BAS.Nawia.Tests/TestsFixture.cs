using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Tests
{
    public class TestsFixture : IDisposable
    {
        public TestsFixture()
        {
            IoC.InitializeIoC();
        }

        public void Dispose()
        {
            //IoC.DisposeIoC();
        }
    }
}
