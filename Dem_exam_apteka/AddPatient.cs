using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Dem_exam_apteka
{
    public partial class AddPatient : Form
    {
        public AddPatient()
        {
            InitializeComponent();

            ShowPatients();

            //int count = 0;
            /*foreach (Patients patients1 in Program.wftDb.Patients)
            {
                count = (patients1.ID_Patients)++;

            }*/
            
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
            //Patients patients = new Patients();
            patient_new patients = new patient_new();
            
            patients.ID_patients_new = Convert.ToInt32(textBoxID.Text);
            patients.name = textBoxName.Text;
            patients.surname = textBoxSurname.Text;
            patients.birthdate_timestamp = textBoxDR.Text;
            patients.phone = textBoxPhone.Text;
            patients.email = textBoxMail.Text;

            Program.wftDb.patient_new.Add(patients);

            Program.wftDb.SaveChanges();
            ShowPatients();
        }

        void ShowPatients()
        {
            listViewPatient.Items.Clear();

            foreach(patient_new patients in Program.wftDb.patient_new)
            {
                ListViewItem item = new ListViewItem(new string[] {
                    patients.ID_patients_new.ToString(), patients.name, patients.surname, patients.birthdate_timestamp,
                    patients.phone, patients.email
                });

                item.Tag = patients;

                listViewPatient.Items.Add(item);
            }
            listViewPatient.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(listViewPatient.SelectedItems.Count == 1)
            {
                patient_new patients = listViewPatient.SelectedItems[0].Tag as patient_new;
                patients.ID_patients_new = Convert.ToInt32(textBoxID.Text);
                patients.name = textBoxName.Text;
                patients.surname = textBoxSurname.Text;
                patients.birthdate_timestamp = textBoxDR.Text;
                patients.phone = textBoxPhone.Text;
                patients.email = textBoxMail.Text;

                Program.wftDb.patient_new.Add(patients);

                Program.wftDb.SaveChanges();
                ShowPatients();
            }

            
        }

        private void listViewPatient_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listViewPatient.SelectedItems.Count == 1)
            {
                patient_new patients = listViewPatient.SelectedItems[0].Tag as patient_new;
                
                //patients.ID_Patients = Convert.ToInt32(textBoxID.Text);
                
                textBoxName.Text = patients.name;
                textBoxSurname.Text = patients.surname;
                textBoxDR.Text = patients.birthdate_timestamp;
                textBoxPhone.Text = patients.phone;
                textBoxMail.Text= patients.email;
                
            }
            else
            {
                textBoxName.Text = "";
                textBoxSurname.Text = "";
                textBoxDR.Text = "";
                textBoxPhone.Text = "";
                textBoxMail.Text = "";
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (listViewPatient.SelectedItems.Count == 1)
                {
                    patient_new patients = listViewPatient.SelectedItems[0].Tag as patient_new;

                    Program.wftDb.patient_new.Remove(patients);

                    Program.wftDb.SaveChanges();
                    ShowPatients();
                }

                textBoxName.Text = "";
                textBoxSurname.Text = "";
                textBoxDR.Text = "";
                textBoxPhone.Text = "";
                textBoxMail.Text = "";
            }
            
            catch
            {
                MessageBox.Show("Невозможно удалить!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
