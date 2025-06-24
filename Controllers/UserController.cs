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
                var existingManager = ItaskContext.Manager.Find(idManager.Id);

                if (existingManager != null)
                {
                    Programmer programmer = new Programmer(name, username, password, experienceLevel, existingManager);
                    ItaskContext.Programmers.Add(programmer);
                    ItaskContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Manager não encontrado!");
                }
            }
            return true;
        }
    }




}
