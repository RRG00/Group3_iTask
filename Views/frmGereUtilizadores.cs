using iTasks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmGereUtilizadores : Form
    {
        private ITaskContext ItaskContext;
        public frmGereUtilizadores()
        {
            InitializeComponent();

            ItaskContext = new ITaskContext();

            cbDepartamento.DataSource = Enum.GetValues(typeof(Department));
            cbNivelProg.DataSource = Enum.GetValues(typeof(ExperienceLevel));

            txtIdProg.Text = FindAvailableID().ToString();
            txtIdGestor.Text = FindAvailableID().ToString();

            cbDepartamento.SelectedIndex = -1;
            cbNivelProg.SelectedIndex = -1;
            cbGestorProg.SelectedIndex = -1;

            UpdateFields();
            UpdateManagerList();
            UpdateProgrammerList();

        }

        private void btGravarGestor_Click(object sender, EventArgs e)
        {
            using (var ItaskContext = new ITaskContext())
            {
               
                string name = txtNomeGestor.Text;
                string username = txtUsernameGestor.Text;
                string password = txtPasswordGestor.Text;
                Department Departamento = (Department)cbDepartamento.SelectedItem;
                bool GereUtilizadores = chkGereUtilizadores.Checked;

                Manager manager = new Manager(name, username, password, Departamento, GereUtilizadores);
                ItaskContext.Manager.Add(manager);
                ItaskContext.SaveChanges();

                UpdateManagerList();
                UpdateFields();

                LimparCamposGestor();

            }
        }
        public void LimparCamposGestor()
        {
            txtIdGestor.Clear();
            txtNomeGestor.Clear();
            txtUsernameGestor.Clear();
            txtPasswordGestor.Clear();
            cbDepartamento.SelectedIndex = -1;
            chkGereUtilizadores.Checked = false;
        }
        private void btCleanGestor_Click(object sender, EventArgs e)
        {
            LimparCamposGestor();
        }
       
        public void LimparCamposProg()
        {
            txtIdProg.Clear();
            txtNomeProg.Clear();
            txtUsernameProg.Clear();
            txtPasswordProg.Clear();
            cbNivelProg.SelectedIndex = -1;
            cbGestorProg.SelectedIndex = -1;
        }  

        private void btCleanProg_Click(object sender, EventArgs e)
        {
            LimparCamposProg();
        }

        public void UpdateFields()
        {
            using (var ItaskContext = new ITaskContext())
            {
                cbGestorProg.DataSource = ItaskContext.Manager.ToList();
            }
        }

        public void UpdateManagerList()
        {
            using (var ItaskContext = new ITaskContext())
            {
                lstListaGestores.DataSource = null;
                lstListaGestores.DataSource = ItaskContext.Manager.ToList();
            }
        }
        public void UpdateProgrammerList()
        {
            using (var ItaskContext = new ITaskContext())
            {
                lstListaProgramadores.DataSource = null;
                lstListaProgramadores.DataSource = ItaskContext.Programmers.ToList();
            }
        }
        public int FindAvailableID()
        {
            using (var ItaskContext = new ITaskContext())
            {
                return ItaskContext.Users.Select(e => e.Id).DefaultIfEmpty(0).Max() + 1;
            }
        }

        private void btGravarProg_Click(object sender, EventArgs e)
        {
            using (var ItaskContext = new ITaskContext())
            {
                string name = txtNomeProg.Text;
                string username = txtUsernameProg.Text;
                string password = txtPasswordProg.Text;
                ExperienceLevel experienceLevel = (ExperienceLevel)cbNivelProg.SelectedItem;
                int idManager = ((Manager)cbGestorProg.SelectedItem).Id;

                Programmer programmer = new Programmer(name, username, password, experienceLevel, idManager);
                ItaskContext.Programmers.Add(programmer);
                ItaskContext.SaveChanges();

                UpdateProgrammerList();

                LimparCamposProg();
                
            }

        }

        private void btAttGestor_Click(object sender, EventArgs e)
        {
            /*
            using (var dbContext = new CarContext())
            {
                var indexSelected = listBoxClients.SelectedIndex;
                Client ClientSelect = (Client)listBoxClients.SelectedItem;
                ClientSelect.Name = textBoxName.Text;
                ClientSelect.Nif = textBoxNif.Text;
                dbContext.Clients.AddOrUpdate(ClientSelect);
                dbContext.SaveChanges();
                listBoxClients.DataSource = dbContext.Clients.ToList();
                listBoxClients.SelectedIndex = indexSelected;
            }
            */
        }

        private void btApagarGestor_Click(object sender, EventArgs e)
        {
            /*
            using (var dbContext = new CarContext())
            {
                Client ClientSelect = (Client)listBoxClients.SelectedItem;
                if (ClientSelect != null)
                {
                    dbContext.Clients.Remove(dbContext.Clients.Find(ClientSelect.Id));
                    dbContext.SaveChanges();
                    listBoxClients.DataSource = dbContext.Clients.ToList();
                }

            }
            */
        }

        private void lstListaGestores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstListaGestores.SelectedIndex;
            if (index == -1) return;

            using (var ItaskContext = new ITaskContext())
            {
                User manager = (User)lstListaGestores.Items[index];
                var man = ItaskContext.Manager.Find(manager.Id);

                txtIdGestor.Text = man.Id.ToString();
                txtNomeGestor.Text = man.Name;
                txtUsernameGestor.Text = man.Username;
                txtPasswordGestor.Text = man.Password;
                cbDepartamento.SelectedItem = man.Department;
                chkGereUtilizadores.Checked = man.GereUsers;
            }
        }

        private void lstListaProgramadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstListaProgramadores.SelectedIndex;
            if (index == -1) return; 

            using (var ItaskContext = new ITaskContext())
            {
                User programmer = (User)lstListaProgramadores.Items[index];
                var prog = ItaskContext.Programmers.Find(programmer.Id);


                txtIdProg.Text = prog.Id.ToString();
                txtNomeProg.Text = prog.Name;
                txtUsernameProg.Text = prog.Username;
                txtPasswordProg.Text = prog.Password;
                cbNivelProg.SelectedItem = prog.ExperienceLevel;
                cbGestorProg.SelectedItem = prog.IdManager;


            }
        }
    }
}
