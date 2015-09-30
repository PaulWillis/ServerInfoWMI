using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerInfo.Infrastructure.Interfaces
{
    public interface IConfigService
    {
        string OperationsConnection { get; }
    }
}
