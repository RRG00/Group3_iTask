using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTasks.Models;

namespace iTasks.Controllers
{
    internal class TaskController
    {
        public bool CreateTask(string Description, int OrderExecution, int StoryPoints, int idTypeTask, int idManager, int idProgrammer, DateTime start, DateTime end)
        {
            try
            {
                using (var ItaskContext = new ITaskContext())
                {
                    Console.WriteLine($"Start: {start}");
                    Console.WriteLine($"End:   {end}");

                    if (start >= end)
                    {
                        throw new ArgumentException("A data de início deve ser anterior à data de fim.");
                    }

                    Task task = new Task(Description, OrderExecution, StoryPoints, idTypeTask, idManager, idProgrammer, start, end);
                    ItaskContext.Tasks.Add(task);
                    Console.WriteLine($"Task: {task.DateStart}");
                    ItaskContext.SaveChanges();
                }
                return true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Erro de validação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show($"ERRO!!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
        }

     
    }
}
