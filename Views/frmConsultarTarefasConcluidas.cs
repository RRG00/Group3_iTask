using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmConsultarTarefasConcluidas : Form
    {
        private int gestorId; // ID do gestor logado

        public frmConsultarTarefasConcluidas(int idGestor)
        {

            InitializeComponent();
            this.gestorId = idGestor;
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultarTarefasConcluidas_Load(object sender, EventArgs e)
        {
            CarregarTarefasAtivas();
        }

        private void CarregarTarefasAtivas()
        {
            using (var context = new ITaskContext())
            {
                var dataAtual = DateTime.Now;

                // Buscar tarefas criadas pelo gestor, excluindo as concluídas
                var tarefasDb = context.Tasks
                    .Where(t => t.IdManager == gestorId && t.CurrentState != "Done")
                    .ToList();

                // Definir ordem de prioridade dos estados
                var ordemEstados = new Dictionary<string, int>
                {
                    { "Overdue", 1 },    // Atrasadas (prioridade máxima)
                    { "InProgress", 2 }, // Em progresso
                    { "Assigned", 3 },   // Atribuídas
                    { "Created", 4 }     // Criadas
                };

                var tarefas = tarefasDb
                    .Select(t => new
                    {
                        Id = t.Id,
                        Descricao = t.Description,
                        Estado = t.CurrentState,
                        Programador = context.Programmers.FirstOrDefault(p => p.Id == t.IdProgrammer)?.Name ?? "Não Atribuído",
                        DataInicio = t.DateStart,
                        DataFim = t.DateEnd,
                        TempoRestante = CalcularTempoRestante(t.DateEnd, dataAtual),
                        Atraso = CalcularAtraso(t.DateEnd, dataAtual),
                        OrdemEstado = ordemEstados.ContainsKey(t.CurrentState) ? ordemEstados[t.CurrentState] : 99
                    })
                    .OrderBy(t => t.OrdemEstado) // Primeiro por estado
                    .ThenBy(t => t.DataFim)      // Depois por data de fim
                    .Select(t => new
                    {
                        t.Descricao,
                        Estado = TraduzirEstado(t.Estado),
                        t.Programador,
                        DataInicio = t.DataInicio.ToString("dd/MM/yyyy"),
                        DataFim = t.DataFim.ToString("dd/MM/yyyy"),
                        TempoRestante = t.TempoRestante,
                        Atraso = t.Atraso
                    })
                    .ToList();

                dataGridTarefasConlcuidas.DataSource = tarefas;

                // Configurar aparência da grid
                ConfigurarGrid();
            }
        }

        private string CalcularTempoRestante(DateTime dataFim, DateTime dataAtual)
        {
            var diferenca = dataFim - dataAtual;

            if (diferenca.TotalDays < 0)
            {
                return "Prazo Expirado";
            }
            else if (diferenca.TotalDays < 1)
            {
                return $"{diferenca.Hours}h restantes";
            }
            else
            {
                return $"{diferenca.Days} dias restantes";
            }
        }

        private string CalcularAtraso(DateTime dataFim, DateTime dataAtual)
        {
            var diferenca = dataAtual - dataFim;

            if (diferenca.TotalDays <= 0)
            {
                return "No Prazo";
            }
            else if (diferenca.TotalDays < 1)
            {
                return $"{diferenca.Hours}h de atraso";
            }
            else
            {
                return $"{diferenca.Days} dias de atraso";
            }
        }

        private string TraduzirEstado(string estado)
        {
            switch (estado)
            {
                case "Created": return "Criada";
                case "Assigned": return "Atribuída";
                case "InProgress": return "Em Progresso";
                case "Overdue": return "Atrasada";
                case "Done": return "Concluída";
                default: return estado;
            }
        }

        private void ConfigurarGrid()
        {
            // Configuração básica da grid - deixar com aparência padrão
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            CarregarTarefasAtivas();
        }
    }
}