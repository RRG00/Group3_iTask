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

                //Limpar campos apos submit
                txtIdGestor.Clear();
                txtNomeGestor.Clear();
                txtUsernameGestor.Clear();
                txtPasswordGestor.Clear();
                cbDepartamento.SelectedIndex = 0;
                chkGereUtilizadores.Checked = false;

            }
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

        private void txtNomeGestor_Click(object sender, EventArgs e)
        {
            txtIdGestor.Text = FindAvailableID().ToString();
        }

        private void txtNomeProg_Click(object sender, EventArgs e)
        {
            txtIdProg.Text = FindAvailableID().ToString();
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


                //Limpa os campos
                txtIdProg.Clear();
                txtNomeProg.Clear();
                txtUsernameProg.Clear();
                txtPasswordProg.Clear();
                cbNivelProg.SelectedIndex = 0;
                cbGestorProg.SelectedIndex = 0;
                
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
            using (var ItaskContext = new ITaskContext())
            {
                User manager = (User)lstListaGestores.Items[index];

                txtNomeGestor.Text = ItaskContext.Manager.Find(manager.Id).Name;
                txtUsernameGestor.Text = ItaskContext.Manager.Find(manager.Id).Username;
                txtPasswordGestor.Text = ItaskContext.Manager.Find(manager.Id).Password;
                cbDepartamento.SelectedItem = ItaskContext.Manager.Find(manager.Id).Department;
                chkGereUtilizadores.Checked = ItaskContext.Manager.Find(manager.Id).GereUsers;
                

            }
            
        }
    }
}
