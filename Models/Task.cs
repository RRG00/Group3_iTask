using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iTasks.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int IdManager { get; set; }
        public int IdProgrammer { get; set; }
        public string OrderExecution { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public  DateTime DateEnd { get; set; }
        public int IdTypeTask { get; set; }
        public int StoryPoints { get; set; }
        public DateTime RealTimeStart { get; set; }
        public DateTime RealTimeEnd { get; set; }
        public DateTime CreationTime { get; set; }
        public string CurrentState  { get; set; }
        public Task()
        {

        }
        public Task(int idManager, int idProgrammer, string orderExecution, string description, DateTime dateStart, DateTime dateEnd, int idTypeTask, int storyPoints, DateTime realTimeStart, DateTime realTimeEnd, DateTime creationTime, string currentState)
        {
            IdManager = idManager;
            IdProgrammer = idProgrammer;
            OrderExecution = orderExecution;
            Description = description;
            DateStart = dateStart;
            DateEnd = dateEnd;
            IdTypeTask = idTypeTask;
            StoryPoints = storyPoints;
            RealTimeStart = realTimeStart;
            RealTimeEnd = realTimeEnd;
            CreationTime = creationTime;
            CurrentState = currentState;
        }

        public override string ToString()
        {
            return Description + " - " + "IdTypeTask:" + IdTypeTask + "-" + "Programador:" + IdProgrammer;
        }
    }
}
