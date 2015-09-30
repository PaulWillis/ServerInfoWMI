using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerInfo.DomainEntities
{
    public struct Login
    {
        public ServerEnums.Domain DomainType;
        public string Domain;
        public string UserName;
        public string Password; 
    }
     
}
