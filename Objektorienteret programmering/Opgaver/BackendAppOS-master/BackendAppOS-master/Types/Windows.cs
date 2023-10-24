using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Types
{
    public class Windows : OS, IOS
    {
        public Windows(string userFullName):base(userFullName)
        {
        }
            
        public string ShowOSType() => $"Welcome {UserFullName} to Windows, running from backend!";
    }
}
