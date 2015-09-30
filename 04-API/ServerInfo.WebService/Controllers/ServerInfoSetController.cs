using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Infrastructure.Data;
using ServerInfo.DomainEntities;
using System.Configuration;
using ServerInfo.Domain.Interfaces;

namespace ServerInfoWebService.Controllers
{
    //[Authorize]
    public class ServerInfoSetController : ApiController
    {
        // Services will be injected
        private IServerRecordRepository _repo; 

        public ServerInfoSetController(IServerRecordRepository repo) 
        {
            this._repo = repo;
        }

        // GET api/values
        public IQueryable<ServerRecord> Get()
        {
            var serverrecords = _repo.GetServerRecordSet();
            return serverrecords;
        }
    }
}
