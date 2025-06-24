using iTasks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Windows.Forms;



namespace iTasks
{
    public partial class frmKanban : Form
    {
        private List<iTasks.Models.Task> listaToDo;
        private List<iTasks.Models.Task> listaDoing;
        private List<iTasks.Models.Task> listaDone;
        private User user;

        public frmKanban(User _user)
        {
            user = _user;

            string username = user.ToString();

            InitializeComponent();
            UpdateStateTaskList();

            label1.Text = "Bem vindo: " + username;
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
            Form newForm = new frmDetalhesTarefa(user);
            newForm.ShowDialog();
            UpdateStateTaskList();

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
            if (lstTodo.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma tarefa para executar.");
                return;
            }

            var task = (iTasks.Models.Task)lstTodo.SelectedItem;

            // Só pode mover as suas próprias tarefas
            if (task.IdProgrammer != user.Id)
            {
                MessageBox.Show("Só pode mover as suas próprias tarefas!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new ITaskContext())
            {
                // Limite de 2 tarefas em Doing
                int doingCount = context.Tasks.Count(t => t.CurrentState == "Doing" && t.IdProgrammer == user.Id);
                if (doingCount >= 2)
                {
                    MessageBox.Show("Só pode ter 2 tarefas em 'Doing' em simultâneo.", "Limite atingido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Só pode avançar a tarefa com menor OrderExecution em ToDo
                var nextTask = context.Tasks
                    .Where(t => t.IdProgrammer == user.Id && t.CurrentState == "ToDo")
                    .OrderBy(t => t.OrderExecution)
                    .FirstOrDefault();

                if (nextTask == null || nextTask.Id != task.Id)
                {
                    MessageBox.Show("Tem de executar as tarefas pela ordem definida pelo gestor!", "Ordem Obrigatória", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var taskDb = context.Tasks.Find(task.Id);
                if (taskDb != null)
                {
                    taskDb.CurrentState = "Doing";
                    taskDb.RealTimeStart = DateTime.Now;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Tarefa não encontrada no banco de dados.");
                }
            }

            UpdateStateTaskList();
        }






        private void btSetTodo_Click(object sender, EventArgs e)
        {
            if (lstDoing.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma tarefa em 'Doing' para reiniciar a Tarefa");
                return;
            }

            var task = (iTasks.Models.Task)lstDoing.SelectedItem;

            if (task.IdProgrammer != user.Id)
            {
                MessageBox.Show("Só pode mover as suas próprias tarefas!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new ITaskContext())
            {
                var taskDb = context.Tasks.Find(task.Id);
                if (taskDb != null)
                {
                    taskDb.CurrentState = "ToDo";
                    taskDb.RealTimeStart = null;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Tarefa não encontrada no banco de dados.");
                }
            }

            UpdateStateTaskList();
        }



        private void btSetDone_Click(object sender, EventArgs e)
        {
            if (lstDoing.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma tarefa em 'Doing' para concluir.");
                return;
            }

            var task = (iTasks.Models.Task)lstDoing.SelectedItem;

            if (task.IdProgrammer != user.Id)
            {
                MessageBox.Show("Só pode mover as suas próprias tarefas!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new ITaskContext())
            {
                var taskDb = context.Tasks.Find(task.Id);
                if (taskDb != null)
                {
                    taskDb.CurrentState = "Done";
                    taskDb.RealTimeEnd = DateTime.Now;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Tarefa não encontrada no banco de dados.");
                }
            }

            UpdateStateTaskList();
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
                        taskDb.RealTimeEnd = null;
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

        private void deleteTask_Click(object sender, EventArgs e)
        {
            var tarefaSelecionada = lstTodo.SelectedItem as Task;
            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Só pode apagar tarefas da coluna 'ToDo'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmResult = MessageBox.Show("Tem a certeza que quer apagar esta tarefa?",
                                                "Confirmar Apagar",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
                return;

            try
            {
                using (var context = new ITaskContext())
                {
                    var tarefaBD = context.Tasks.FirstOrDefault(t => t.Id == tarefaSelecionada.Id);
                    if (tarefaBD != null)
                    {
                        context.Tasks.Remove(tarefaBD);
                        context.SaveChanges();
                        MessageBox.Show("Tarefa apagada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Tarefa não encontrada na base de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao apagar a tarefa: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateStateTaskList();
        }

        private void lstDoing_DoubleClick(object sender, EventArgs e)
        {
            if (lstDoing.SelectedItem != null)
            {
                var tarefaSelecionada = (iTasks.Models.Task)lstDoing.SelectedItem;
                frmDetalhesTarefa detalhesForm = new frmDetalhesTarefa(tarefaSelecionada, true);
                detalhesForm.ShowDialog();
            }
        }

        private void lstDone_DoubleClick(object sender, EventArgs e)
        {

            if (lstDone.SelectedItem != null)
            {
                var tarefaSelecionada = (iTasks.Models.Task)lstDone.SelectedItem;
                frmDetalhesTarefa detalhesForm = new frmDetalhesTarefa(tarefaSelecionada, true);
                detalhesForm.ShowDialog();
            }
        }

        private void lstTodo_DoubleClick(object sender, EventArgs e)
        {
            if (lstTodo.SelectedItem != null)
            {
                var tarefaSelecionada = (iTasks.Models.Task)lstTodo.SelectedItem;
                frmDetalhesTarefa detalhesForm = new frmDetalhesTarefa(tarefaSelecionada, true);
                detalhesForm.ShowDialog();
            }
        }
    }


}
