using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    public class Programmer : User
    {
        public string ExperienceLevel {get; set;}
        public int IdManager { get; set;}
        public Programmer()
        {

        }
        public Programmer(string experienceLevel, int idManager)
        {
            ExperienceLevel = experienceLevel;
            IdManager = idManager;
        }
       
    }
}
