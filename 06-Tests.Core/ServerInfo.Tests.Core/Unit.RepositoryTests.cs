using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerInfo.Domain.Interfaces;
using Ninject;
using ServerInfo.Infrastructure.DependecyResolution;
using ServerInfo.Infrastructure.Interfaces;
using System.Linq;
using ServerInfo.DomainEntities;
using ServerInfoWebService.Controllers;

namespace ServerInfo.Tests.Core
{
    [TestClass]
    public class RepositoryTests
    {
        // Ninject kernel
        private IKernel _ninjectKernel;

        public RepositoryTests()
        {
            // Init Ninject kernel
            _ninjectKernel = new StandardKernel
                (
                    new TestConfigModule(),
                    new RepositoryModule()
                );
        }

        [TestMethod]
        public void Should_Get_All_ServerConnections()
        {

            var config = _ninjectKernel.Get<IConfigService>();

            var serverConns = _ninjectKernel.Get<IServerRecordRepository>();

            IQueryable<ServerConnection> res = serverConns.GetServerSet();
            
            Assert.AreEqual(res.Count(), 12);
        }
         

        [TestMethod]
        public void Should_Get_All_ServerRecords()
        {

            var config = _ninjectKernel.Get<IConfigService>();

            var serverRecordsRep = _ninjectKernel.Get<IServerRecordRepository>();

            IQueryable<ServerRecord> res = serverRecordsRep.GetServerRecordSet();

            Assert.AreEqual(res.Count(), 76);
        }
    }
}
