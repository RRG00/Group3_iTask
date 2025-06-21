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
    public partial class frmConsultaTarefasEmCurso : Form
    {
        public frmConsultaTarefasEmCurso()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultaTarefasEmCurso_Load(object sender, EventArgs e)
        {
            using (var context = new ITaskContext())
            {
                var tarefasDb = context.Tasks
                    .Where(t => t.CurrentState == "Doing")
                    .ToList();

                var tarefas = tarefasDb
                    .Select(t => new
                    {
                        Descricao = t.Description,
                        Programador = context.Programmers.FirstOrDefault(p => p.Id == t.IdProgrammer)?.Name ?? "N/A",
                        TempoPrevisto = (t.DateEnd - t.DateStart).Days,
                        TempoReal = (t.RealTimeEnd - t.RealTimeStart).Days
                    })
                    .ToList();

                dataGridTarefasEmcurso.DataSource = tarefas;
            }
        }
    }
}
