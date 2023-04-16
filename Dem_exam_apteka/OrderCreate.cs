using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Collections;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dem_exam_apteka
{
    public partial class OrderCreate : Form
    {
        public OrderCreate()
        {
            InitializeComponent();

            PriemBiomateriala priemBiomateriala1 = new PriemBiomateriala();
            textBoxName.Text = priemBiomateriala1.name;
            textBoxServices.Text = priemBiomateriala1.usluga;
            labelDateZakaz.Text = DateTime.Now.ToString("ddMMyyyy");
            labelNumberZakaz.Text = "1";
            textBoxDR.Text = priemBiomateriala1.dr;
            //textBoxPolis.Text = priemBiomateriala1.polis;
            textBoxCode.Text = priemBiomateriala1.id_prob;
            textBoxCost.Text = "2345,78";

        }
        public Single searchServices(ArrayList array) { Single cost = 0; 
            for (int i = 0; i < array.Count; i++) { SqlDataAdapter adapter = new SqlDataAdapter(); 
                DataTable table = new DataTable(); 
                string conn = "Data Source=localhost;Initial Catalog=DB;Integrated Security=True"; 
                string sqlQuerry = $"SELECT Price FROM services WHERE Service = '{array[i]}'"; 
                SqlConnection connect = new SqlConnection(conn); connect.Open(); 
                SqlCommand command = new SqlCommand(sqlQuerry, connect); 
                adapter.SelectCommand = command; adapter.Fill(table); 
                Single costForOne = (from DataRow dr in table.Rows select (Single)dr["Price"]).FirstOrDefault(); 
                cost += costForOne; } return cost; }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            PriemBiomateriala priemBiomateriala = new PriemBiomateriala();
            priemBiomateriala.Show();this.Hide();
        }

        private void buttonSformirovatOrder_Click(object sender, EventArgs e)
        {
            PdfDocument document = new PdfDocument(); PdfPage page = document.AddPage(); XFont font = new XFont("Comic Sans MS", 15, XFontStyle.Bold); XGraphics gfx = XGraphics.FromPdfPage(page);
            gfx.DrawString($"Дата заказа | {labelDateZakaz.Text}", font, XBrushes.Black, new XRect(10, -10, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString($"Номер заказа |{labelNumberZakaz.Text}", font, XBrushes.Black, new XRect(10, 10, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString($"Номер пробирки | {textBoxCode.Text}", font, XBrushes.Black, new XRect(0, 30, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString($"Пациент | {textBoxName.Text}", font, XBrushes.Black, new XRect(10, 50, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString($"День рождения | {textBoxDR.Text}", font, XBrushes.Black, new XRect(10, 70, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString($"Услуга | {textBoxServices.Text}", font, XBrushes.Black, new XRect(10, 90, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString($"Стоимость | {textBoxCost.Text}", font, XBrushes.Black, new XRect(10, 110, page.Width, page.Height), XStringFormats.Center);
            
            //gfx.DrawString($"Дата заказа| Номер заказа| Номер пробирки| Номер страхового полиса| ФИО| Дата рождения| Перечень услуг| Стоимость", font, XBrushes.Black, new XRect(0, -10, page.Width, page.Height), XStringFormats.Center);
            //gfx.DrawString($"{labelDateZakaz.Text}|{labelNumberZakaz.Text}|{textBoxCode.Text}|{textBoxPolis.Text}|{textBoxName.Text}|{textBoxDR.Text}|{textBoxServices.Text}|{textBoxCost.Text}", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
            string filename = "orderPayment.pdf";
            document.Save(filename);
            //orderPlace(textBoxServices.Text, textBoxCost.Text, textBoxName.Text);
            /*Order order = new Order();
            order.patient = textBoxName.Text;
            order.services = textBoxServices.Text;
            order.cost = textBoxCost.Text;
            Program.wftDb.Order.Add(order);
            Program.wftDb.SaveChanges();
            ShowOrder();*/
            MessageBox.Show("Запись сохранена и выгружена в PDF", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void orderPlace(string patient, string services, string cost ) 
        {
            /*Order order = new Order();
            order.patient = textBoxName.Text;
            order.services = textBoxServices.Text;
            order.cost = textBoxCost.Text;
            Program.wftDb.Order.Add(order);
            Program.wftDb.SaveChanges();
            ShowOrder();*/

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string conn = "Data Source=localhost;Initial Catalog=chemist_shop;Integrated Security=True";
            string sqlQuerry = $"insert into Order(patient,services,cost) values ('{patient}','{services}','{cost}')";
            SqlConnection connect = new SqlConnection(conn);
            connect.Open();
            SqlCommand command = new SqlCommand(sqlQuerry, connect);
            adapter.SelectCommand = command;
            adapter.Fill(table);
        }


        private void ShowOrder()
        {

            foreach (Order order in Program.wftDb.Order)
            {
                {
                    order.patient.ToString(); order.services.ToString(); order.cost.ToString();
                    
                };

                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderPlace(textBoxServices.Text, textBoxCost.Text, textBoxName.Text);
            /*Order order = new Order();
            order.patient = textBoxName.Text;
            order.services = textBoxServices.Text;
            order.cost = textBoxCost.Text;
            Program.wftDb.Order.Add(order);
            Program.wftDb.SaveChanges();
            ShowOrder();*/
            MessageBox.Show("Запись сохранена", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    
}
    

