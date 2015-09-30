using Infrastructure.Data;
using Ninject;
using Ninject.Modules;
using ServerInfo.Domain.Interfaces;
using ServerInfo.Infrastructure.Data;
using ServerInfo.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerInfo.Infrastructure.DependecyResolution
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            
            BindRepositories();
        }
        
        private void BindRepositories()
        {
            // Get config service
            var configService = Kernel.Get<IConfigService>();

            // Bind repositories
            Bind<IServerRecordRepository>().To<ServerRecordRepository>()
                .WithConstructorArgument("connectionString", configService.OperationsConnection); 
                        

        }
    }
}
