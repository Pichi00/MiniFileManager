using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Model
{
    public class Drive
    {
        public string Name { get; set; }

        public Drive(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
