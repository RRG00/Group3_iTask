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
    public partial class frmKanban : Form
    {
        public frmKanban()
        {
            InitializeComponent();
        }

        private void buttonNewTask_Click(object sender, EventArgs e)
        {
            Form newForm = new frmGereTiposTarefas();
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
    }
}
