using ServerInfo.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{


    public class Utils
    {
        public static List<Login> GetAllLogins()
        {
            Login login = new Login();
            List<Login> loginList = new List<Login>();

            foreach (ServerEnums.Domain domaintype in Enum.GetValues(typeof(ServerEnums.Domain)))
            {
                Console.WriteLine(String.Format("Enter domain name for {0}:", domaintype.ToString()));
                string domain = Console.ReadLine();
                Console.WriteLine("Enter username:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password:");
                string password = Utils.GetPassword().ToString();
                Console.WriteLine("");

                login.Domain = domain;
                login.UserName = username;
                login.Password = password;
                login.DomainType = domaintype;

                loginList.Add(login);
            }


            return loginList;
        }



        public static List<Login> GetAllLoginsBypassPrompt()
        {
            Login login1 = new Login();
            Login login2 = new Login();
            List<Login> loginList = new List<Login>();

            login1.Domain = "oxxx";
            login1.UserName = "xxx";
            login1.Password = "xxxx";
            login1.DomainType = ServerEnums.Domain.Domain_O;


            login2.Domain = "cxxxx";
            login2.UserName = "xxx";
            login2.Password = "xxxx";
            login2.DomainType = ServerEnums.Domain.Domain_C;


            loginList.Add(login1);
            loginList.Add(login2);


            return loginList;
        }



        public static string GetPassword()
        {
            string pass = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // prevent backspace
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // stop when enter pressed
            while (key.Key != ConsoleKey.Enter);

            return pass;
        }

    }
}
