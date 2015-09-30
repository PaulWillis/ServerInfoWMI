using ServerInfo.DomainEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerInfo.Domain.Interfaces
{
    public interface IServerRecordRepository
    {
        IQueryable<ServerConnection> GetServerSet();
        IQueryable<ServerRecord> GetServerRecordSet();
    }
}
