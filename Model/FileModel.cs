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
        
        public FileTypes.types Type {get;}

        public FileModel(string name, FileTypes.types type)
        {

            Type = type;
            Name = name;
        }

        public override string ToString()
        {
            if (Type == FileTypes.types.DIR)
            {
                return "<DIR>"+Name;
            }
            return Name;
                
        }

    }
}
