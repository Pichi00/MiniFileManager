using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Model
{
    internal class File
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public enum types { FILE, DIR }
        public File.types Type {get; set; }
        
    }
}
