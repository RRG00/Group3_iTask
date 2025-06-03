using iTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTasks.Controllers
{
    internal class TaskController
    {
        public bool CreateTask(string Description, int OrderExecution, int StoryPoints, int idTypeTask, int idManager, int idProgrammer, DateTime start, DateTime end)
        {
            using (var ItaskContext = new ITaskContext())
            {
                Task task = new Task(Description, OrderExecution, StoryPoints, idTypeTask, idManager, idProgrammer, start, end);
                ItaskContext.Tasks.Add(task);
                ItaskContext.SaveChanges();
            }
            return true;
        }
    }
}
