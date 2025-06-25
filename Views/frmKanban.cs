using iTasks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private string GetUserRole(User user)
        {
            if (user is Manager)
            {
                return "Manager";
            }
            else if (user is Programmer)
            {
                return "Programmer";
            }
            else
            {
                return "Unknown";
            }
        }
                
        private void frmKanban_Load(object sender, EventArgs e)
        {
            
            string userRole = GetUserRole(user);
            if (userRole == "Programmer")
            {
                buttonNewTask.Visible = false;
                deleteTask.Visible = false;
                exportarParaCSVToolStripMenuItem.Visible = false;
                utilizadoresToolStripMenuItem.Visible = false;
                buttonTaskDoing.Visible = false;

            }
        }

        private void btPrevisao_Click(object sender, EventArgs e)
        {
            try
            {
                double tempoMedio = CalcularTempoPrevistoParaTarefasToDo();

                if (tempoMedio > 0)
                {
                    MessageBox.Show($"O tempo médio por story point é {tempoMedio:F2} horas",
                                   "Tempo Médio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não existem tarefas por prever (nenhuma tarefa em 'ToDo').",
                                   "Sem Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao calcular tempo médio: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double CalcularTempoPrevistoParaTarefasToDo()
        {
            using (var context = new ITaskContext())
            {
                var tarefasConcluidas = context.Tasks
                    .Where(t => t.CurrentState == "Done" &&
                                t.RealTimeStart.HasValue &&
                                t.RealTimeEnd.HasValue &&
                                t.StoryPoints > 0)
                    .ToList();

                var mediasPorSP = tarefasConcluidas
                    .GroupBy(t => t.StoryPoints)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Average(t => (t.RealTimeEnd.Value - t.RealTimeStart.Value).TotalHours)
                    );

                if (!mediasPorSP.Any())
                    return 0;

                var tarefasToDo = context.Tasks
                    .Where(t => t.CurrentState == "ToDo" && t.StoryPoints > 0)
                    .ToList();

                double tempoPrevistoTotal = 0;

                foreach (var tarefa in tarefasToDo)
                {
                    double tempoPrevisto;

                    if (mediasPorSP.ContainsKey(tarefa.StoryPoints))
                    {
                        tempoPrevisto = mediasPorSP[tarefa.StoryPoints];
                    }
                    else
                    {
                        var spMaisProximo = mediasPorSP.Keys
                            .OrderBy(sp => Math.Abs(sp - tarefa.StoryPoints))
                            .First();
                        tempoPrevisto = mediasPorSP[spMaisProximo];
                    }

                    tempoPrevistoTotal += tempoPrevisto;
                }

                return tempoPrevistoTotal;
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
            string userRole = GetUserRole(user);
            Form newForm = new frmConsultarTarefasConcluidas(user.Id, userRole);
            newForm.ShowDialog();
        }

        private void tarefasEmCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userRole = GetUserRole(user);
            Form newForm = new frmConsultaTarefasEmCurso(user.Id, userRole);
            newForm.Show();
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

                // Verificar se é gestor para permitir edição
                bool isReadOnly = !(user is Manager);

                // Passar o user para o construtor
                frmDetalhesTarefa detalhesForm = new frmDetalhesTarefa(tarefaSelecionada, isReadOnly, user);
                detalhesForm.ShowDialog();

                // Se foi editado por um gestor, atualizar as listas
                if (!isReadOnly)
                {
                    UpdateStateTaskList();
                }
            }
        }

        private void lstDone_DoubleClick(object sender, EventArgs e)
        {
            if (lstDone.SelectedItem != null)
            {
                var tarefaSelecionada = (iTasks.Models.Task)lstDone.SelectedItem;

                // Verificar se é gestor para permitir edição
                bool isReadOnly = !(user is Manager);

                // Passar o user para o construtor
                frmDetalhesTarefa detalhesForm = new frmDetalhesTarefa(tarefaSelecionada, isReadOnly, user);
                detalhesForm.ShowDialog();

                // Se foi editado por um gestor, atualizar as listas
                if (!isReadOnly)
                {
                    UpdateStateTaskList();
                }
            }
        }

        private void lstTodo_DoubleClick(object sender, EventArgs e)
        {
            if (lstTodo.SelectedItem != null)
            {
                var tarefaSelecionada = (iTasks.Models.Task)lstTodo.SelectedItem;

                // Verificar se é gestor para permitir edição
                bool isReadOnly = !(user is Manager);

                // Passar o user para o construtor
                frmDetalhesTarefa detalhesForm = new frmDetalhesTarefa(tarefaSelecionada, isReadOnly, user);
                detalhesForm.ShowDialog();

                // Se foi editado por um gestor, atualizar as listas
                if (!isReadOnly)
                {
                    UpdateStateTaskList();
                }
            }
        }

        private void exportarParaCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Filtrar apenas tarefas concluídas
                List<iTasks.Models.Task> tarefasConcluidas;
                using (var context = new ITaskContext())
                {
                    tarefasConcluidas = context.Tasks.Where(t => t.CurrentState == "Done").ToList();
                }

                    if (tarefasConcluidas.Count > 0)
                    {
                        // Abrir diálogo para escolher local de gravação
                        using (SaveFileDialog saveDialog = new SaveFileDialog())
                        {
                            saveDialog.Filter = "Ficheiros CSV (*.csv)|*.csv";
                            saveDialog.Title = "Guardar Tarefas Concluídas";
                            saveDialog.FileName = $"TarefasConcluidas_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                            if (saveDialog.ShowDialog() == DialogResult.OK)
                            {
                                ExportarParaCSV(tarefasConcluidas, saveDialog.FileName);
                                MessageBox.Show($"Tarefas exportadas com sucesso!\nFicheiro: {saveDialog.FileName}",
                                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não existem tarefas concluídas para exportar.", "Informação",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar tarefas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarParaCSV(List<Task> tarefasConcluidas, string caminhoFicheiro)
        {
            using (StreamWriter writer = new StreamWriter(caminhoFicheiro, false, Encoding.UTF8))
            {
                // Cabeçalho - primeira linha com nomes das colunas
                writer.WriteLine("Programador;Descricao;DataPrevistaInicio;DataPrevistaFim;TipoTarefa;DataRealInicio;DataRealFim");

                // Dados das tarefas
                foreach (var tarefa in tarefasConcluidas)
                {
                    string linha =
                                  $"{EscaparCampoCSV(tarefa.IdProgrammer.ToString())};" +
                                  $"{EscaparCampoCSV(tarefa.Description)};" +
                                  $"{tarefa.DateStart:dd/MM/yyyy};" +
                                  $"{tarefa.DateEnd:dd/MM/yyyy};" +
                                  $"{EscaparCampoCSV(tarefa.IdTypeTask.ToString())};" +
                                  $"{(tarefa.RealTimeStart.HasValue ? tarefa.RealTimeStart.ToString() : "")};" +
                                  $"{(tarefa.RealTimeEnd.HasValue ? tarefa.RealTimeEnd.ToString() : "")}";

                    writer.WriteLine(linha);
                }
            }
        }
        // teste
        // Método para escapar campos que contenham ponto e vírgula, aspas ou quebras de linha
        private string EscaparCampoCSV(string campo)
        {
            if (string.IsNullOrEmpty(campo))
                return string.Empty;

            // Se o campo contém ponto e vírgula, aspas ou quebra de linha, envolver em aspas
            if (campo.Contains(";") || campo.Contains("\"") || campo.Contains("\n") || campo.Contains("\r"))
            {
                // Duplicar aspas existentes e envolver em aspas
                return "\"" + campo.Replace("\"", "\"\"") + "\"";
            }

            return campo;
        }
    }


}
