using iTasks.Controllers;
using iTasks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            int OrderExecution = int.Parse(txtOrdem.Text);
            int StoryPoints  = int.Parse(txtStoryPoints.Text);
            int idManager = CurrentUser.Id;
            int idTypeTask = TypeTask.Id;
            int idProgrammer = Programmer.Id;
            DateTime start = dtInicio.Value;
            DateTime end = dtFim.Value;

            TaskController controller = new TaskController();

            controller.CreateTask(Description, OrderExecution, StoryPoints, idManager, idTypeTask, idProgrammer, start, end);

            
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

      
    }
}
