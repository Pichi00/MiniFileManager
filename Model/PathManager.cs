using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiniTC.Model
{
    class PathManager
    {
        public string[] getLogicalDrives()
        {
            return Directory.GetLogicalDrives();
        }

        public string getCurrentPath()
        {
            return "";
        }
    }
}
