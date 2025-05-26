using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    public class Programmer : User
    {

        public ExperienceLevel ExperienceLevel { get; set; }
        public Manager IdManager { get; set; }

        public Programmer()
        {

        }

        public Programmer(string name, string username, string password, ExperienceLevel experienceLevel, Manager idManager) : base(name, username, password)
        {
            this.IdManager = idManager;
        }

        public override string ToString()
        {
            return Username + " - " + "ID:" + Id;
        }
    }
}
