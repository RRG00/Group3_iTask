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

                lstTodo.DataSource = null;
                lstTodo.DataSource = listaToDo;

                lstDoing.DataSource = null;
                lstDoing.DataSource = listaDoing;
            }
        }



        private void frmKanban_Load(object sender, EventArgs e)
        {

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

        private void lstTodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstTodo.SelectedIndex;
            if (index == -1) return;

            iTasks.Models.Task selectedTask = (iTasks.Models.Task)lstTodo.Items[index];



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
    }
}
