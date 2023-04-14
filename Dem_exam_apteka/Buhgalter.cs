using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dem_exam_apteka
{
    public partial class Buhgalter : Form
    {
        public Buhgalter()
        {
            InitializeComponent();

            labelSurname.Text = LoginForm.users.name;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); this.Hide();
        }

        
    }
}
