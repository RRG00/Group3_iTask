using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmLogin : Form
    {

        ITaskContext ITaskContext;
        public frmLogin()
        {
            ITaskContext dbContext = new ITaskContext();
            InitializeComponent();

        }

        //Login Button
        private void btLogin_Click(object sender, EventArgs e)
        {
            string name = txtUsername.Text;
            string password = txtPassword.Text;
            Form secondForm = new frmKanban();

            if (name == "admin" && password == "123")
            {
                MessageBox.Show("Login efetuado com sucesso!");
                Hide();
                secondForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("ERRO! Introduza os dados certos");
                return;
            }
            
            
        }
    }
}
