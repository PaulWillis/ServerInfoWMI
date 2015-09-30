using Ninject.Modules;
using ServerInfo.Infrastructure.Interfaces;
using ServerInfo.WebService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerInfo.WebService.DependencyResolution
{
    public class ConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigService>().To<ConfigService>();
        }
    }
}
