global using BackendApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Interface
{
    public interface IOS
    {
        public string UserFullName { get; set; }
        public string ShowOSType();

    }
}
