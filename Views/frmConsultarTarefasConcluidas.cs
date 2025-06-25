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
        private int _currentUserId;
        private string _userType;

        public frmConsultarTarefasConcluidas(int currentUserId, string userType)
        {
            InitializeComponent();
            _currentUserId = currentUserId;
            _userType = userType;
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultarTarefasConcluidas_Load(object sender, EventArgs e)
        {
            using (var context = new ITaskContext())
            {
                if (_userType == "Programmer" || _userType == "Programador")
                {
                    CarregarTarefasProgramador(context);
                }
                else
                {
                    CarregarTarefasOriginal(context);
                }
            }
        }

        private void CarregarTarefasOriginal(ITaskContext context)
        {
            var tarefasDb = context.Tasks
                .Where(t => t.CurrentState == "Done")
                .ToList();

            var tarefas = tarefasDb
                .Select(t => new
                {
                    Descricao = t.Description,
                    Programador = context.Programmers.FirstOrDefault(p => p.Id == t.IdProgrammer)?.Name ?? "N/A",
                    TempoPrevisto = (t.DateEnd - t.DateStart).Days,
                    TempoReal = t.RealTimeEnd.HasValue && t.RealTimeStart.HasValue
                        ? (t.RealTimeEnd.Value - t.RealTimeStart.Value).Days : (int?)null
                })
                .ToList();

            dataGridTarefasConlcuidas.DataSource = tarefas;
        }

        private void CarregarTarefasProgramador(ITaskContext context)
        {
            var tarefasDb = context.Tasks
                .Where(t => t.CurrentState == "Done" && t.IdProgrammer == _currentUserId)
                .ToList();

            var tarefas = tarefasDb
                .Select(t => new
                {
                    Descricao = t.Description,
                    TempoRealDias = t.RealTimeEnd.HasValue && t.RealTimeStart.HasValue
                        ? Math.Ceiling((t.RealTimeEnd.Value - t.RealTimeStart.Value).TotalDays)
                        : (double?)null
                })
                .ToList();

            dataGridTarefasConlcuidas.DataSource = tarefas;
            ConfigurarColunasProgramador();
        }

        private void CarregarTarefasGestor(ITaskContext context)
        {
            var tarefasDb = context.Tasks
                .Where(t => t.CurrentState == "Done")
                .ToList();

            var tarefas = tarefasDb
                .Select(t => new
                {
                    Descricao = t.Description,
                    Programador = context.Programmers.FirstOrDefault(p => p.Id == t.IdProgrammer)?.Name ?? "N/A",
                    TempoPrevistoDias = Math.Ceiling((t.DateEnd - t.DateStart).TotalDays),
                    TempoRealDias = t.RealTimeEnd.HasValue && t.RealTimeStart.HasValue
                        ? Math.Ceiling((t.RealTimeEnd.Value - t.RealTimeStart.Value).TotalDays)
                        : (double?)null,
                    Diferenca = t.RealTimeEnd.HasValue && t.RealTimeStart.HasValue
                        ? Math.Ceiling((t.RealTimeEnd.Value - t.RealTimeStart.Value).TotalDays) - Math.Ceiling((t.DateEnd - t.DateStart).TotalDays)
                        : (double?)null,
                    Status = t.RealTimeEnd.HasValue && t.RealTimeStart.HasValue
                        ? (Math.Ceiling((t.RealTimeEnd.Value - t.RealTimeStart.Value).TotalDays) <= Math.Ceiling((t.DateEnd - t.DateStart).TotalDays) ? "Entregue no Prazo" : "Entregué fora de Prazo")
                        : "N/A"
                })
                .ToList();

            dataGridTarefasConlcuidas.DataSource = tarefas;
            ConfigurarColunasGestor();
        }

        private void ConfigurarColunasProgramador()
        {
            if (dataGridTarefasConlcuidas.Columns.Count > 0)
            {
                dataGridTarefasConlcuidas.Columns["Descricao"].HeaderText = "Descrição da Tarefa";
                dataGridTarefasConlcuidas.Columns["TempoRealDias"].HeaderText = "Tempo em dias";
                dataGridTarefasConlcuidas.Columns["Descricao"].Width = 300;
                dataGridTarefasConlcuidas.Columns["TempoRealDias"].Width = 120;
            }
        }

        private void ConfigurarColunasGestor()
        {
            if (dataGridTarefasConlcuidas.Columns.Count > 0)
            {
                dataGridTarefasConlcuidas.Columns["Descricao"].HeaderText = "Descrição da Tarefa";
                dataGridTarefasConlcuidas.Columns["Programador"].HeaderText = "Programador";
                dataGridTarefasConlcuidas.Columns["TempoPrevistoDias"].HeaderText = "Tempo Previsto (Dias)";
                dataGridTarefasConlcuidas.Columns["TempoRealDias"].HeaderText = "Tempo Real (Dias)";
                dataGridTarefasConlcuidas.Columns["Diferenca"].HeaderText = "Diferença (Dias)";
                dataGridTarefasConlcuidas.Columns["Status"].HeaderText = "Status";

                dataGridTarefasConlcuidas.Columns["Descricao"].Width = 200;
                dataGridTarefasConlcuidas.Columns["Programador"].Width = 120;
                dataGridTarefasConlcuidas.Columns["TempoPrevistoDias"].Width = 120;
                dataGridTarefasConlcuidas.Columns["TempoRealDias"].Width = 120;
                dataGridTarefasConlcuidas.Columns["Diferenca"].Width = 100;
                dataGridTarefasConlcuidas.Columns["Status"].Width = 200;
            }
        }
    }
}