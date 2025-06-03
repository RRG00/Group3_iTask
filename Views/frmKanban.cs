using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmKanban : Form
    {
        private List<iTasks.Models.Task> listaToDo;
        private List<iTasks.Models.Task> listaDoing;
        private List<iTasks.Models.Task> listaDone;

        public frmKanban()
        {
          
            InitializeComponent();

            using (ITaskContext context = new ITaskContext())
            {
                if (!context.Tasks.Any())
                {
                    context.Tasks.Add(new Models.Task(1, 1, "1", "Exemplo de Task", DateTime.Now, DateTime.Now, 1, 21, DateTime.Now, DateTime.Now, DateTime.Now, "ToDo"));
                    context.SaveChanges();
                }
            }

            UpdateStateTaskList();

        }
        


        public void UpdateTypeTaskList()
        {
            using (var ItaskContext = new ITaskContext())
            {
                lstTodo.DataSource = null;
                lstTodo.DataSource = ItaskContext.Tasks.ToList();
            }
        }
        public void UpdateStateTaskList()
        {
            using (var ItaskContext = new ITaskContext())
            {
                listaToDo = ItaskContext.Tasks.Where(t => t.CurrentState == "ToDo").ToList();
                listaDoing = ItaskContext.Tasks.Where(t => t.CurrentState == "Doing").ToList();
                listaDone = ItaskContext.Tasks.Where(t => t.CurrentState == "Done").ToList();

                lstTodo.DataSource = null;
                lstTodo.DataSource = listaToDo;
                lstTodo.SelectedIndex = -1;
                   

                lstDoing.DataSource = null;
                lstDoing.DataSource = listaDoing;
                lstDoing.SelectedIndex = -1;

                lstDone.DataSource = null;
                lstDone.DataSource = listaDone;
                lstDone.SelectedIndex = -1;
            }
            }


        private void buttonNewTask_Click(object sender, EventArgs e)
        {
            Form newForm = new frmDetalhesTarefa();
            newForm.ShowDialog();

        }

        private void buttonNewUsers_Click(object sender, EventArgs e)
        {
            Form newForm = new frmGereUtilizadores();
            newForm.ShowDialog();
        }

        private void gerirTiposDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newForm = new frmGereTiposTarefas();
            newForm.ShowDialog();
        }

        private void tarefasTerminadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newForm = new frmConsultarTarefasConcluidas();
            newForm.ShowDialog();
        }

        private void tarefasEmCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newForm = new frmConsultaTarefasEmCurso();
            newForm.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmKanban_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void lstTodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTodo.SelectedIndex != -1)
            {
                lstDoing.ClearSelected();
                lstDone.ClearSelected();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btSetDoing_Click(object sender, EventArgs e)
        {
            if (lstTodo.SelectedItem != null)
            {
                var task = (iTasks.Models.Task)lstTodo.SelectedItem;

                using (var context = new ITaskContext())
                {
                    // Busca a tarefa pelo ID no contexto atual
                    var taskDb = context.Tasks.Find(task.Id);
                    if (taskDb != null)
                    {
                        taskDb.CurrentState = "Doing";
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Tarefa não encontrada no banco de dados.");
                    }
                }

                UpdateStateTaskList();
            }
            else
            {
                MessageBox.Show("Selecione uma tarefa para executar.");
            }
        }

        private void btSetTodo_Click(object sender, EventArgs e)
        {
            if (lstDoing.SelectedItem != null)
            {
                var task = (iTasks.Models.Task)lstDoing.SelectedItem;

                using (var context = new ITaskContext())
                {
                    var taskDb = context.Tasks.Find(task.Id);
                    if (taskDb != null)
                    {
                        taskDb.CurrentState = "ToDo";
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Tarefa não encontrada no banco de dados.");
                    }
                }

                UpdateStateTaskList();
            }
            else
            {
                MessageBox.Show("Selecione uma tarefa em 'Doing' para reniciar a Tarefa");
            }
        }

        private void btSetDone_Click(object sender, EventArgs e)
        {
            if (lstDoing.SelectedItem != null)
            {
                var task = (iTasks.Models.Task)lstDoing.SelectedItem;

                using (var context = new ITaskContext())
                {
                    var taskDb = context.Tasks.Find(task.Id);
                    if (taskDb != null)
                    {
                        taskDb.CurrentState = "Done";
                        context.SaveChanges();
                    }
                }

                UpdateStateTaskList();
            }
            else
            {
                MessageBox.Show("Selecione uma tarefa em 'Doing' para terminar a tarefa.");
            }
        }

        /*funcao so para trabalhar no projeto
           pq para o projeto final não deve ser possivel para tarefas Done para Doing */
        private void buttonDoneDoing_Click(object sender, EventArgs e)
        {
            if (lstDone.SelectedItem != null)
            {
                var task = (iTasks.Models.Task)lstDone.SelectedItem;

                using (var context = new ITaskContext())
                {
                    var taskDb = context.Tasks.Find(task.Id);
                    if (taskDb != null)
                    {
                        taskDb.CurrentState = "Doing";
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Tarefa não encontrada no banco de dados.");
                    }
                }

                UpdateStateTaskList();
            }
            else
            {
                MessageBox.Show("Selecione uma tarefa em 'Done' para voltar para 'Doing'.");
            }
        }

    }


}
