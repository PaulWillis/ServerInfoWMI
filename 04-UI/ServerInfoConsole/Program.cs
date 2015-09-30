using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management; 
using System.Security; 
using Utils;
using ServerInfo.DomainEntities;
using Infrastructure.Data;
using System.Configuration;
using ServerInfo.Infrastructure.Data;

namespace ServerInfoConsole
{

    class Program
    {
        static void Main(string[] args)
        {
            DateTime runTime = DateTime.Now;

            DAL dal = new DAL(ConfigurationManager.ConnectionStrings["DBServer"].ConnectionString);

            Utils.OperationResult canConnectToDB = dal.TestSqlServerConnectionString();
                
            if (canConnectToDB.Success == false)
            {
                foreach (string msg in canConnectToDB.MessageList)
                {
                    Console.WriteLine(msg);
                }
                Console.WriteLine("Cannot connect to database.");
                Console.WriteLine("Press any key to exit the program.");
                Console.ReadLine();
                Environment.Exit(0);
            }


            //List<Login> LoginList = Utils.Utils.GetAllLogins();
            List<Login> LoginList = Utils.Utils.GetAllLoginsBypassPrompt();
             

            ServerRecordRepository srepo = new ServerRecordRepository(ConfigurationManager.ConnectionStrings["DBServer"].ConnectionString);
            

            IEnumerable<ServerConnection> ServerList = srepo.GetServerSet();
            foreach (ServerConnection srv in ServerList)
            { 
                if (srv.DomainAlias.ToString() == "Domain_O")
                {
                    srepo.GetServerInfo(srv.ServerIP, ServerEnums.Domain.Domain_O, LoginList, runTime);
                }
                else
                {
                    srepo.GetServerInfo(srv.ServerIP, ServerEnums.Domain.Domain_C, LoginList, runTime);

                }  
            
            }

        }

    }
}
