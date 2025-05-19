using iTasks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            cbDepartamento.DataSource = Enum.GetValues(typeof(Department));
            ItaskContext = new ITaskContext();
            
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
                              
                Manager manager = new Manager(name,username,password, Departamento,GereUtilizadores);
                ItaskContext.Manager.Add(manager);
                ItaskContext.SaveChanges();
            }
        }

        private void txtUsernameGestor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdGestor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
