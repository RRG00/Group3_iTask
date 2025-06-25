using System;
using System.Linq;
using System.Windows.Forms;
using iTasks.Models;

namespace iTasks
{
    public partial class frmConsultaTarefasEmCurso : Form
    {
        private int _currentUserId;
        private string _userType;

        public frmConsultaTarefasEmCurso(int currentUserId, string userType)
        {
            InitializeComponent();
            _currentUserId = currentUserId;
            _userType = userType;
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultaTarefasEmCurso_Load(object sender, EventArgs e)
        {
            int gestorId = _currentUserId;

            using (var context = new ITaskContext())
            {
                var tarefasDb = context.Tasks
                    .Where(t => t.IdManager == gestorId && t.CurrentState != "Done" && t.CurrentState != "Done")
                    .OrderBy(t => t.CurrentState)
                    .ToList();

                var tarefas = tarefasDb
                    .Select(t => new
                    {
                        Descricao = t.Description,
                        Programador = context.Programmers.FirstOrDefault(p => p.Id == t.IdProgrammer)?.Name ?? "N/A",
                        Estado = t.CurrentState,
                        TempoEmFalta = t.DateEnd > DateTime.Now
                            ? (t.DateEnd - DateTime.Now).Days + " dias"
                            : "0 dias",
                        TempoAtraso = t.DateEnd < DateTime.Now
                            ? (DateTime.Now - t.DateEnd).Days + " dias"
                            : "0 dias"
                    })
                    .ToList();

                dataGridTarefasEmcurso.DataSource = tarefas;
            }
        }
    }
}
