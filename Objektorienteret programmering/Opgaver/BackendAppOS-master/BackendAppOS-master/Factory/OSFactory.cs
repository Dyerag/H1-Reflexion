using BackendApp.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Factory
{
    internal class OSFactory
    {
        public IOS Identify(string myUserFolderUrl)
        {
            if (myUserFolderUrl.Contains("C:"))
            {
                return new Windows("Niels Olesen");
            }
            else if (myUserFolderUrl.Contains("/"))
            {
                return new Linux("Niels Olesen");
            }
            else
                return null;
        }
    }
}
