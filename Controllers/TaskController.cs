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
        public bool CreateTask(
                string Description,
                int OrderExecution,
                int StoryPoints,
                int idTypeTask,
                int idManager,
                int idProgrammer,
                DateTime start,
                DateTime end)
        {

            if (string.IsNullOrWhiteSpace(Description))
            {
                MessageBox.Show("A descrição não pode estar vazia.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (OrderExecution <= 0)
            {
                MessageBox.Show("A ordem de execução deve ser maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (StoryPoints <= 0)
            {
                MessageBox.Show("Os Story Points devem ser maiores que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (idTypeTask <= 0)
            {
                MessageBox.Show("Selecione um tipo de tarefa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (idManager <= 0)
            {
                MessageBox.Show("Selecione um gestor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (idProgrammer <= 0)
            {
                MessageBox.Show("Selecione um programador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (start >= end)
            {
                MessageBox.Show("A data de início deve ser anterior à data de fim!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            try
            {
                using (var ItaskContext = new ITaskContext())
                {
                    Task task = new Task(Description, OrderExecution, StoryPoints, idTypeTask, idManager, idProgrammer, start, end);
                    ItaskContext.Tasks.Add(task);
                    ItaskContext.SaveChanges();
                }
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}