using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class OperationResult
    {
        public bool Success { get; set; }

        public List<string> MessageList { get; private set; }

        public OperationResult()
        {
            MessageList = new List<string>();
            Success = false;
        }

        public void AddMessage(string message)
        {
            MessageList.Add(message);
        }

    }

}
