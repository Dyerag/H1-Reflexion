using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Types
{
    public class Linux : OS, IOS
    {
        public Linux(string userFullName) : base(userFullName) { }

        public string ShowOSType() => $"Welcome {UserFullName} to Linux, running from backend!";
    }
}
