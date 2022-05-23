using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniTC.Model
{
    public class FileModel
    {
        
        public string Name { get; set; }
        //public string Path { get; set; }
        
        public FileTypes.types Type {get;}

        public FileModel(string name, FileTypes.types type)
        {
            Type = type;
            Name = name;
            if (type == FileTypes.types.DIR)
            {
                Name.Insert(0, "<D>");
            }
        }
        
    }
}
