using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    public class Programmer : User
    {
        public ExperienceLevel ExperienceLevel {get; set;}
        public int IdManager { get; set;}

        public Programmer(string name, string username, string password, ExperienceLevel experienceLevel, int idManager)
        {
            this.ExperienceLevel = experienceLevel;
            this.IdManager = idManager;
        }
        public Programmer()
        {

        }

        public override string ToString()
        {
            return Name + " - " + Id;
        }


    }
}
