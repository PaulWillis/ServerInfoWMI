using ServerInfo.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerInfo.Tests.Core
{
    public class TestConfigService : IConfigService
    {
        public string OperationsConnection
        {
            get
            {
                string cnString =  "Data Source = 10.0.6.147; Initial Catalog = Operations; Integrated Security=SSPI;Connection Timeout=30000"; 
                return cnString;
            }
        }
    }
}
