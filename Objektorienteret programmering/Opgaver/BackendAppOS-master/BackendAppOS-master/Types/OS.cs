using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Types
{
    public class OS
    {
        public string UserFullName { get; set; }

        public OS(string userFullName)
        {
            UserFullName = userFullName;
        }
    }
}
