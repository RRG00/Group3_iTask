using iTasks.Controllers;
using iTasks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        private UserController userController = new UserController();
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

                userController.CreateManager(name, username, password, Departamento, GereUtilizadores);

                UpdateManagerList();
                UpdateFields();

                CleanManagerFields();

            }
        }
        public void CleanManagerFields()
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
            CleanManagerFields();
        }

        public void CleanProgFields()
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
            CleanProgFields();
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
                var indexSelected = lstListaGestores.SelectedIndex;

                lstListaGestores.DataSource = null;
                lstListaGestores.DataSource = ItaskContext.Manager.ToList();

            }
        }
        public void UpdateProgrammerList()
        {
            using (var ItaskContext = new ITaskContext())
            {
                var indexSelected = lstListaProgramadores.SelectedIndex;

                lstListaProgramadores.DataSource = null;
                lstListaProgramadores.DataSource = ItaskContext.Programmers.ToList();
                lstListaProgramadores.SelectedIndex = indexSelected;
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
                Manager idManager = (Manager)cbGestorProg.SelectedItem;

                userController.CreateProgrammer(name, username, password, experienceLevel, idManager);

                UpdateProgrammerList();

                CleanProgFields();

            }

        }

        private void btAttGestor_Click(object sender, EventArgs e)
        {

            using (var ItaskContext = new ITaskContext())
            {
                Manager ManagerSelect = (Manager)lstListaGestores.SelectedItem;

                ManagerSelect.Name = txtNomeGestor.Text;
                ManagerSelect.Username = txtUsernameGestor.Text;
                ManagerSelect.Password = txtPasswordGestor.Text;
                ManagerSelect.Department = (Department)cbDepartamento.SelectedItem;
                ManagerSelect.GereUsers = chkGereUtilizadores.Checked;

                ItaskContext.Manager.AddOrUpdate(ManagerSelect);
                ItaskContext.SaveChanges();

                UpdateManagerList();
            }

        }

        private void btApagarGestor_Click(object sender, EventArgs e)
        {

            using (var ITaskContext = new ITaskContext())
            {
                Manager ManagerSelect = (Manager)lstListaGestores.SelectedItem;
                if (ManagerSelect != null)
                {
                    ItaskContext.Manager.Remove(ItaskContext.Manager.Find(ManagerSelect.Id));
                    ItaskContext.SaveChanges();

                    UpdateManagerList();
                }

            }

        }

        private void btAttProg_Click(object sender, EventArgs e)
        {
            using (var ItaskContext = new ITaskContext())
            {
                Programmer ProgrammerSelect = (Programmer)lstListaProgramadores.SelectedItem;

                ProgrammerSelect.Name = txtNomeProg.Text;
                ProgrammerSelect.Username = txtUsernameProg.Text;
                ProgrammerSelect.Password = txtPasswordProg.Text;
                ProgrammerSelect.ExperienceLevel = (ExperienceLevel)cbNivelProg.SelectedItem;
                ProgrammerSelect.IdManager = (Manager)cbGestorProg.SelectedItem;

                ItaskContext.Programmers.AddOrUpdate(ProgrammerSelect);
                ItaskContext.SaveChanges();

                UpdateProgrammerList();
            }
        }

        private void btApagarProg_Click(object sender, EventArgs e)
        {
            using (var ITaskContext = new ITaskContext())
            {
                Programmer ProgrammerSelect = (Programmer)lstListaProgramadores.SelectedItem;
                if (ProgrammerSelect != null)
                {
                    ItaskContext.Programmers.Remove(ItaskContext.Programmers.Find(ProgrammerSelect.Id));
                    ItaskContext.SaveChanges();

                    UpdateManagerList();
                }

            }
        }




        private void lstListaGestores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstListaGestores.SelectedIndex;
            if (index == -1) return;

            using (var ItaskContext = new ITaskContext())
            {
                User manager = (User)lstListaGestores.Items[index];
                var mang = ItaskContext.Manager.Find(manager.Id);

                txtIdGestor.Text = mang.Id.ToString();
                txtNomeGestor.Text = mang.Name;
                txtUsernameGestor.Text = mang.Username;
                txtPasswordGestor.Text = mang.Password;
                cbDepartamento.SelectedItem = mang.Department;
                chkGereUtilizadores.Checked = mang.GereUsers;
            }
        }

        private void lstListaProgramadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstListaProgramadores.SelectedIndex;
            if (index == -1) return;

            using (var context = new ITaskContext())
            {
                User programmer = (User)lstListaProgramadores.Items[index];
                var prog = context.Programmers.Find(programmer.Id);

                txtIdProg.Text = prog.Id.ToString();
                txtNomeProg.Text = prog.Name;
                txtUsernameProg.Text = prog.Username;
                txtPasswordProg.Text = prog.Password;
                cbNivelProg.SelectedItem = prog.ExperienceLevel;

                foreach (User user in cbGestorProg.Items.Cast<User>())
                {
                    if (user.Id == prog.IdManager.Id)
                    {
                        cbGestorProg.SelectedItem = user;
                        break;
                    }
                }
            }
        }

        private void s(object sender, EventArgs e)
        {

        }


    }
}
