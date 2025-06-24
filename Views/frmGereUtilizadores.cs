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
            var errors = new List<string>();

            string name = txtNomeGestor.Text.Trim();
            string username = txtUsernameGestor.Text.Trim();
            string password = txtPasswordGestor.Text;
            Department? department = cbDepartamento.SelectedItem != null ? (Department?)cbDepartamento.SelectedItem : null;
            bool manageUsers = chkGereUtilizadores.Checked;

            // Validations
            if (string.IsNullOrWhiteSpace(name)) errors.Add("Nome é obrigatório");
            if (string.IsNullOrWhiteSpace(username)) errors.Add("Username é obrigatório");
            if (string.IsNullOrWhiteSpace(password)) errors.Add("Password é obrigatório");
            else if (password.Length < 6) errors.Add("Password tem que ter no minímo 6 caracteres");
            if (department == null) errors.Add("Selecione o departamento");

            if (errors.Any())
            {
                MessageBox.Show($"Por favor corrija:\n• {string.Join("\n• ", errors)}", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new ITaskContext())
                {
                    userController.CreateManager(name, username, password, department.Value, manageUsers);
                    UpdateManagerList();
                    UpdateFields();
                    CleanManagerFields();
                    MessageBox.Show("Manager criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error ao criar um manager:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Guardar seleção atual
                var selectedManager = cbGestorProg.SelectedItem as Manager;
                int? selectedId = selectedManager?.Id;

                // Limpar completamente
                cbGestorProg.DataSource = null;
                cbGestorProg.Items.Clear();

                // Recarregar com gestores únicos
                var managers = ItaskContext.Manager.Distinct().ToList();
                cbGestorProg.DataSource = managers;
                cbGestorProg.DisplayMember = "Name";
                cbGestorProg.ValueMember = "Id";

                // Restaurar seleção se existir
                if (selectedId.HasValue)
                {
                    foreach (Manager manager in cbGestorProg.Items)
                    {
                        if (manager.Id == selectedId.Value)
                        {
                            cbGestorProg.SelectedItem = manager;
                            break;
                        }
                    }
                }
                else
                {
                    cbGestorProg.SelectedIndex = -1;
                }
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
            var errors = new List<string>();

            string name = txtNomeProg.Text.Trim();
            string username = txtUsernameProg.Text.Trim();
            string password = txtPasswordProg.Text;
            ExperienceLevel? experienceLevel = cbNivelProg.SelectedItem != null ? (ExperienceLevel?)cbNivelProg.SelectedItem : null;
            Manager manager = cbGestorProg.SelectedItem as Manager;

            // Validations
            if (string.IsNullOrWhiteSpace(name)) errors.Add("Nome é obrigatório");
            if (string.IsNullOrWhiteSpace(username)) errors.Add("Username é obrigatório");
            if (string.IsNullOrWhiteSpace(password)) errors.Add("Password é obrigatório");
            else if (password.Length < 6) errors.Add("Password tem que ter no minímo 6 caracteres");
            if (experienceLevel == null) errors.Add("Selecione o nível de experiencia");
            if (manager == null) errors.Add("Selecione um Manager");

            if (errors.Any())
            {
                MessageBox.Show($"Por favor corrija:\n• {string.Join("\n• ", errors)}", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new ITaskContext())
                {
                    userController.CreateProgrammer(name, username, password, experienceLevel.Value, manager);
                    UpdateProgrammerList();
                    CleanProgFields();
                    MessageBox.Show("Programador criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error ao criar um programador:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btAttGestor_Click(object sender, EventArgs e)
        {
            var errors = new List<string>();

            Manager managerSelect = lstListaGestores.SelectedItem as Manager;
            string name = txtNomeGestor.Text.Trim();
            string username = txtUsernameGestor.Text.Trim();
            string password = txtPasswordGestor.Text;
            Department? department = cbDepartamento.SelectedItem != null ? (Department?)cbDepartamento.SelectedItem : null;
            bool manageUsers = chkGereUtilizadores.Checked;

            // Validations
            if (managerSelect == null) errors.Add("Por favor selecione um manager");
            if (string.IsNullOrWhiteSpace(name)) errors.Add("Name é obrigatório");
            if (string.IsNullOrWhiteSpace(username)) errors.Add("Username é obrigatório");
            if (string.IsNullOrWhiteSpace(password)) errors.Add("Password é obrigatório");
            else if (password.Length < 6) errors.Add("Password tem que ter no minimo 6 caracteres");
            if (department == null) errors.Add("Departamento tem que estar selecionado");

            if (errors.Any())
            {
                MessageBox.Show($"Por favor corrija:\n• {string.Join("\n• ", errors)}", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new ITaskContext())
                {
                    managerSelect.Name = name;
                    managerSelect.Username = username;
                    managerSelect.Password = password;
                    managerSelect.Department = department.Value;
                    managerSelect.GereUsers = manageUsers;
                    context.Manager.AddOrUpdate(managerSelect);
                    context.SaveChanges();
                    UpdateManagerList();
                    MessageBox.Show("Update com sucesso!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no update:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btApagarGestor_Click(object sender, EventArgs e)
        {
            Manager managerSelect = lstListaGestores.SelectedItem as Manager;

            if (managerSelect == null)
            {
                MessageBox.Show("Por favor selecione um manager para apagar.", "Aviso",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            var result = MessageBox.Show($"Tem certeza que deseja apagar o manager '{managerSelect.Name}'?",
                                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                using (var context = new ITaskContext())
                {
                    
                    var programmersCount = context.Programmers.Count(p => p.IdManager.Id == managerSelect.Id);

                    if (programmersCount > 0)
                    {
                        MessageBox.Show($"Não é possível apagar este manager pois tem {programmersCount} programador(es) associado(s).\n" +
                                      "Remova ou reatribua os programadores primeiro.", "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    
                    var managerToDelete = context.Manager.Find(managerSelect.Id);
                    if (managerToDelete != null)
                    {
                        context.Manager.Remove(managerToDelete);
                        context.SaveChanges();

                        UpdateFields();
                        UpdateManagerList();
                        CleanManagerFields();

                        MessageBox.Show("Manager apagado com sucesso!", "Sucesso",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao apagar manager:\n{ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btAttProg_Click(object sender, EventArgs e)
        {
            var errors = new List<string>();

            Programmer programmerSelect = lstListaProgramadores.SelectedItem as Programmer;
            string name = txtNomeProg.Text.Trim();
            string username = txtUsernameProg.Text.Trim();
            string password = txtPasswordProg.Text;
            ExperienceLevel? experienceLevel = cbNivelProg.SelectedItem != null ? (ExperienceLevel?)cbNivelProg.SelectedItem : null;
            Manager manager = cbGestorProg.SelectedItem as Manager;

            // Validations
            if (programmerSelect == null) errors.Add("Por favor selecione um programador");
            if (string.IsNullOrWhiteSpace(name)) errors.Add("Nome é obrigatório");
            if (string.IsNullOrWhiteSpace(username)) errors.Add("Username é obrigatório");
            if (string.IsNullOrWhiteSpace(password)) errors.Add("Password é obrigatório");
            else if (password.Length < 6) errors.Add("Password tem que ter no minimo 6 caracteres");
            if (experienceLevel == null) errors.Add("Selecione o nível de experiencia");
            if (manager == null) errors.Add("Selecione um Manager");

            if (errors.Any())
            {
                MessageBox.Show($"Por favor corrija:\n• {string.Join("\n• ", errors)}", "Erros de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new ITaskContext())
                {
                    // Buscar o programador e manager no contexto atual
                    var existingProgrammer = context.Programmers.Find(programmerSelect.Id);
                    var existingManager = context.Manager.Find(manager.Id);

                    if (existingProgrammer != null && existingManager != null)
                    {
                        existingProgrammer.Name = name;
                        existingProgrammer.Username = username;
                        existingProgrammer.Password = password;
                        existingProgrammer.ExperienceLevel = experienceLevel.Value;
                        existingProgrammer.IdManager = existingManager; // Usar o manager do contexto atual

                        context.SaveChanges();
                        UpdateProgrammerList();
                        MessageBox.Show("Update com sucesso!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Programador ou Manager não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no update:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btApagarProg_Click(object sender, EventArgs e)
        {
            using (var ITaskContext = new ITaskContext()) // Mantém o nome que criaste
            {
                Programmer ProgrammerSelect = (Programmer)lstListaProgramadores.SelectedItem;
                if (ProgrammerSelect != null)
                {
                    ITaskContext.Programmers.Remove(ITaskContext.Programmers.Find(ProgrammerSelect.Id)); // USA A VARIÁVEL LOCAL
                    ITaskContext.SaveChanges(); // USA A VARIÁVEL LOCAL

                    UpdateFields();
                    CleanProgFields();
                    UpdateProgrammerList();
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
                var prog = context.Programmers.Include(p => p.IdManager).FirstOrDefault(p => p.Id == programmer.Id);

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

        private void txtNomeGestor_Enter(object sender, EventArgs e)
        {
            if (txtIdGestor.Text == "")
            {
                txtIdGestor.Text = FindAvailableID().ToString();
            }
        }

        private void txtNomeProg_Enter(object sender, EventArgs e)
        {
            if (txtIdProg.Text == "")
            {
                txtIdProg.Text = FindAvailableID().ToString();
            }
        }
    }
}
