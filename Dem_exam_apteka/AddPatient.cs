using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Dem_exam_apteka
{
    public partial class AddPatient : Form
    {
        public AddPatient()
        {
            InitializeComponent();
        }

        private void listViewPatient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            PriemBiomateriala priemBiomateriala = new PriemBiomateriala();
            priemBiomateriala.Show();this.Hide();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Patients patients = new Patients();

            int count = 0;
            foreach (Patients patients1 in Program.wftDb.Patients)
            {
                count = (patients1.id)++;

            }
           
            label7.Text = Convert.ToInt32(count);
            patients.id = label7.Text;
            patients.name = textBoxName.Text;
            patients.surname = textBoxSurname.Text;
            patients.birthdate_timestamp = textBoxDR.Text;
            patients.phone = textBoxPhone.Text;
            patients.email = textBoxMail.Text;

            Program.wftDb.Patients.Add(patients);

            Program.wftDb.SaveChanges();
        }
    }
}
