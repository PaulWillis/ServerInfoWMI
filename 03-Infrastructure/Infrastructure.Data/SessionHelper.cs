using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    class SessionHelper
    { 
        private string _connectionString;

        public SessionHelper(string connectionString)
        {
            _connectionString = connectionString;
        }
         
    }
}
