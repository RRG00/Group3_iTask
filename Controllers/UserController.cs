using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTasks.Models;

namespace iTasks.Controllers
{
    internal class UserController
    {

        public bool CreateManager(string name, string username, string password, Department Departamento, bool GereUtilizadores)
        {
            using (var ItaskContext = new ITaskContext())
            {
                Manager manager = new Manager(name, username, password, Departamento, GereUtilizadores);
                ItaskContext.Manager.Add(manager);
                ItaskContext.SaveChanges();
            }
            return true;
        }

        public bool CreateProgrammer(string name, string username, string password, ExperienceLevel experienceLevel, Manager idManager)
        {
            using (var ItaskContext = new ITaskContext())
            {
                Programmer programmer = new Programmer(name, username, password, experienceLevel, idManager);
                ItaskContext.Programmers.Add(programmer);
                ItaskContext.SaveChanges();
            }
            return true;
        }
    }




}
