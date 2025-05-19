using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    public class Manager : User
    {
        
        public Department Department { get; set; }
        public bool GereUsers { get; set; }

        public Manager(string name, string username, string password, Department departamento, bool gereUtilizadores) : base(name, username, password)
        {
            this.Department = departamento;
            this.GereUsers = gereUtilizadores;
        }

        public Manager()
        {
        }

        public override string ToString()
        {
            return Name + " - " + Id;
        }


    }
}
