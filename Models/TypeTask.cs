using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    public class TypeTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
    public TypeTask()
        {

        }

    public TypeTask(string name)
    {
         this.Name = name;
    }
        public override string ToString()
        {
            return Name + " - " + "ID:" + Id;
        }

    }
}
