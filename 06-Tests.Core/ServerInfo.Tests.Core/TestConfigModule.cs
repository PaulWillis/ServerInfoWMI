using Ninject.Modules;
using ServerInfo.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerInfo.Tests.Core
{

    public class TestConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigService>().To<TestConfigService>();
        }
    }
}
