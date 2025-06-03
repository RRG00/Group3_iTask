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
       
        public frmKanban()
        {
            InitializeComponent();

            using (ITaskContext context = new ITaskContext())
            {
                if (context.Tasks.Count() == 0)
                {
                    context.Tasks.Add(new Models.Task(1, 1, "1", "Exemplo de Task", DateTime.Now,DateTime.Now,1,21,DateTime.Now,DateTime.Now,DateTime.Now,"ToDo"));
                    context.SaveChanges();
                }
                UpdateTypeTaskList();
            }

        }

       
        public void UpdateTypeTaskList()
        {
            using (var ItaskContext = new ITaskContext())
            {
                lstTodo.DataSource = null;
                lstTodo.DataSource = ItaskContext.Tasks.ToList();
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
            if (index == -1) return ;

            iTasks.Models.Task selectedTask = (iTasks.Models.Task)lstTodo.Items[index];



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
