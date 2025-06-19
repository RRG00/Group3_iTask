using iTasks.Controllers;
using iTasks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmDetalhesTarefa : Form
    {
        private ITaskContext ItaskContext;

        private User CurrentUser;

        private TypeTask TypeTask;

        private Programmer Programmer;

        public frmDetalhesTarefa()
        {
            InitializeComponent();

            ItaskContext = new ITaskContext();

            updateFields();
        }

        public frmDetalhesTarefa(User user)
        {
            CurrentUser = user;
            InitializeComponent();

            ItaskContext = new ITaskContext();

            updateFields();

        }

        public frmDetalhesTarefa(TypeTask typeTask)
        {
            TypeTask = typeTask;
            InitializeComponent();

            ItaskContext = new ITaskContext();

            updateFields();

        }

        public frmDetalhesTarefa(Programmer programmer)
        {
            Programmer = programmer;
            InitializeComponent();

            ItaskContext = new ITaskContext();

        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            string Description = txtDesc.Text;
            int OrderExecution;
            if (!int.TryParse(txtOrdem.Text, out OrderExecution) || OrderExecution <= 0)
            {
                MessageBox.Show("A ordem de execução deve ser um número inteiro maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int StoryPoints;
            if (!int.TryParse(txtStoryPoints.Text, out StoryPoints) || StoryPoints <= 0)
            {
                MessageBox.Show("Os Story Points devem ser um número inteiro maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idManager = CurrentUser.Id;
            int idTypeTask = cbTipoTarefa.SelectedItem is TypeTask selectedTypeTask ? selectedTypeTask.Id : 0;
            int idProgrammer = cbProgramador.SelectedItem is Programmer selectedProgrammer ? selectedProgrammer.Id : 0;
            DateTime start = dtInicio.Value;
            DateTime end = dtFim.Value;

            // ---- VALIDAÇÃO DAS DATAS ----
            if (start >= end)
            {
                MessageBox.Show("A data de início deve ser anterior à data de fim!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // -----------------------------

            TaskController controller = new TaskController();

            bool success = controller.CreateTask(Description, OrderExecution, StoryPoints, idManager, idTypeTask, idProgrammer, start, end);
            if (success == false)
            {
                return;
            }
            MessageBox.Show("Tarefa criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }


        public void updateFields()
        {
            using (var itaskContext = new ITaskContext())
            { 
                cbTipoTarefa.DataSource = itaskContext.TipeTasks.ToList();
                cbProgramador.DataSource = itaskContext.Programmers.ToList();
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTipoTarefa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtInicio_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
