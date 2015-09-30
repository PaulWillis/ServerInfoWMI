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
    public class WebAPIControllerTests
    {
        // Ninject kernel
        private IKernel _ninjectKernel;

        public WebAPIControllerTests()
        {
            // Init Ninject kernel
            _ninjectKernel = new StandardKernel
                (
                    new TestConfigModule(),
                    new RepositoryModule()
                );
        }
         
        [TestMethod]
        public void Get_From_Controller()
        { 
            var controller = _ninjectKernel.Get<ServerInfoSetController>();

            IQueryable<ServerRecord> res = controller.Get();

            Assert.AreEqual(res.Count(), 76);
        }
         
    }
}
