using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (ITaskContext context = new ITaskContext())
            {
                if (context.Users.Count() == 0)
                {
                    context.Users.Add(new Models.Manager("admin", "admin", "admin", Models.Department.IT, true));
                    context.SaveChanges();
                }
            }

            Application.Run(new frmLogin());
        }
    }
}
