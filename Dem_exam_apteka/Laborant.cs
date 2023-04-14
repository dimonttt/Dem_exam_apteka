using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types.Condition.Types;
namespace Dem_exam_apteka
{
     
    public partial class Laborant : Form
    {
        public int h = 2;
        public int m = 30;
        public int s = 0;

        public Laborant()
        {
            InitializeComponent();

            labelSurname.Text = LoginForm.users.name;

            timer1.Start();

            
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); this.Hide();

        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            s = s - 1;
            if (s == -1)
            {
                m = m - 1;
                s = 59;
            }

            if (m == -1)
            {
                h = h - 1;
                m = 59;
            }

            if (h == 0 && m == 0 && s == 0)
            {
                timer1.Stop();
                MessageBox.Show("Время вышло!");
                LoginForm loginForm = new LoginForm();
                loginForm.Show();this.Hide();
                loginForm.ZapuskTimer();
                //loginForm.timer2_Tick(loginForm.timer2_Tick);

                
            }

            if (h == 0 && m == 15 && s == 0)
            {
                MessageBox.Show("До конца сенса 15 минут!");
            }
            labelHour.Text = Convert.ToString(h);
            labelMin.Text = Convert.ToString(m);
            labelSec.Text = Convert.ToString(s);


        }
        internal void LoadOrders(String CustomerID)
        {
            //LoginForm.Bloc
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PriemBiomateriala priemBiomateriala = new PriemBiomateriala();
            priemBiomateriala.Show();this.Hide();
        }
    }
}
