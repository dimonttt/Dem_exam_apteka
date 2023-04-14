using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dem_exam_apteka
{

    public struct Blood
    {
        public int id;
       

    }
    public partial class PriemBiomateriala : Form
    {
        Random rnd = new Random();
        public int k = 0; 
        public static Blood bloods = new Blood();
        public PriemBiomateriala()
        {
            InitializeComponent();

            ShowPatients();
            ShowServices();

            int count = 0;
            
            foreach (blood bloodss in Program.wftDb.blood)
            {
                count = (bloodss.id)++;
                
            }
            //pictureBox1.Text = Convert.ToString(count);
            textBoxCode.Text = Convert.ToString(count);
        }
        
        private void ShowPatients()
        {
            comboBoxFIO.Items.Clear();
            foreach (Patients patients in Program.wftDb.Patients)
            {
                foreach(Users user in Program.wftDb.Users)
                {
                    if(patients.id == user.ID)
                    {
                        string[] item = { user.ID.ToString() + ".", user.name };
                        comboBoxFIO.Items.Add(string.Join(",", item));
                    }
                }
            }
        }

        private void ShowServices()
        {
            comboBoxUsluga.Items.Clear();
            foreach(services services in Program.wftDb.services)
            {
                string[] item = { services.Code.ToString() + ".", services.Service };
                comboBoxUsluga.Items.Add(string.Join(",", item));
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Laborant laborant = new Laborant();
            laborant.Show();this.Hide();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 15; i++)
            {
                k = rnd.Next(0, 10);
                label4.Text += k + " ";
            
            }
            pictureBox2.Visible = true;
            label4.Visible = true;
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {

            label1.Font = new Font("IDAutomationHC39M", 12, FontStyle.Regular);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            pictureCode.Visible = true;
            textBoxCode.Visible = true;

            label4.Text = textBoxCode.Text + DateTime.Today.ToString("dd MM yyyy") + "";
            for(int i = 0; i < 6; i++)
            {
                k = rnd.Next(0, 10);
                label4.Text += " " + k;
                    
            }

            
            string barcode = textBoxCode.Text;

            Bitmap bitm = new Bitmap(barcode.Length * 45, 160);
            using (Graphics graphic = Graphics.FromImage(bitm))
            {

                Font newfont = new Font("IDAutomationHC39M", 20);
                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                graphic.FillRectangle(white, 0, 0, bitm.Width, bitm.Height);
                graphic.DrawString("*" + barcode + "*", newfont, black, point);


            }

            using (MemoryStream Mmst = new MemoryStream())
            {


                bitm.Save("ms", ImageFormat.Jpeg);
               
            }
        }

        private void pictureCode_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxFIO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            AddPatient addPatient = new AddPatient();
            addPatient.Show();this.Hide();
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = BarCode.DrawEAN13(label4.Text);
        }*/
    }

    internal static class BarCode
    {
        const float TOTAL_WIDTH = 1.2343f;//31,35 мм
        const float TOTAL_HEIGHT = 1.0209F;//25,93 мм
        const float LINE_LEN = 0.8996f;//22,85 мм
        const float SPACE_UP_DOWN = 0.013f;//0,33 мм
        const float SPACE_LEFT = 0.1429f;//3,63 мм
        const float SPACE_RIGHT = 0.0909f;//2,31 мм
        const float SEPARATOR_LINE_LEN = 0.9646f;//24,5 мм
        const float TEXT_HEIGHT = 0.1083f;//25,91 - 23,16 = 2,75 мм
        const float TEXT_POS = 0.9118f;//23,16 мм

        //Коды для левой шестёрки
        static uint[,] Lcode = new uint[10, 7]{
            {0,0,0,1,1,0,1},
            {0,0,1,1,0,0,1},
            {0,0,1,0,0,1,1},
            {0,1,1,1,1,0,1},
            {0,1,0,0,0,1,1},
            {0,1,1,0,0,0,1},
            {0,1,0,1,1,1,1},
            {0,1,1,1,0,1,1},
            {0,1,1,0,1,1,1},
            {0,0,0,1,0,1,1}
        };
        //Коды для правой шестёрки
        static uint[,] Rcode = new uint[10, 7]{
            {1,1,1,0,0,1,0},
            {1,1,0,0,1,1,0},
            {1,1,0,1,1,0,0},
            {1,0,0,0,0,1,0},
            {1,0,1,1,1,0,0},
            {1,0,0,1,1,1,0},
            {1,0,1,0,0,0,0},
            {1,0,0,0,1,0,0},
            {1,0,0,1,0,0,0},
            {1,1,1,0,1,0,0}
        };
        //Коды разделителей
        static uint[,] Divcode = new uint[3, 5] {
            {1,0,1,2,2},
            {0,1,0,1,0},
            {1,0,1,2,2}
        };

        static internal Bitmap DrawEAN13(string barCodeNum, float DPI = 300)
        {

            Bitmap barCodeBmp = new Bitmap((int)(TOTAL_WIDTH * DPI) + 1, (int)(TOTAL_HEIGHT * DPI) + 1);
            barCodeBmp.SetResolution(DPI, DPI);

            int w = (int)(barCodeBmp.Width + DPI * (SPACE_LEFT + SPACE_RIGHT)), h = (int)(barCodeBmp.Height + 2 * DPI * SPACE_UP_DOWN);
            Bitmap fullImage = new Bitmap(w, h);
            fullImage.SetResolution(DPI, DPI);

            Pen pen = new Pen(Color.White, TOTAL_WIDTH * DPI / 95f);
            float textSpace = 7f * pen.Width / 6f;
            PointF textPt = new PointF(0, TEXT_POS * DPI);//координаты текста
            Font f = new Font("Courier", TEXT_HEIGHT * 72f, FontStyle.Regular);

            using (Graphics g = Graphics.FromImage(barCodeBmp),
                            g1 = Graphics.FromImage(fullImage))
            {

                g.FillRectangle(Brushes.White, new Rectangle(0, 0, barCodeBmp.Width, barCodeBmp.Height));

                //Разделитель слева
                float x = pen.Width / 2, y = SEPARATOR_LINE_LEN * DPI;
                for (int i = 0; i < 3; i++, x += pen.Width)
                {
                    pen.Color = Divcode[0, i] == 0 ? Color.White : Color.Black;
                    g.DrawLine(pen, x, 0, x, y);
                }

                //Левая половина кода
                int n;
                y = LINE_LEN * DPI;
                for (int i = 0; i < 6; i++, textPt.X += textSpace)
                {
                    textPt.X = x;
                    g.DrawString(barCodeNum[i].ToString(), f, Brushes.Black, textPt);
                    n = int.Parse(barCodeNum[i].ToString());
                    for (int j = 0; j < Lcode.GetLength(1); j++, x += pen.Width)
                    {
                        pen.Color = Lcode[n, j] == 0 ? Color.White : Color.Black;
                        g.DrawLine(pen, x, 0, x, y);
                    }
                }

                //Разделитель по центру
                y = SEPARATOR_LINE_LEN * DPI;
                for (int i = 0; i < Divcode.GetLength(1); i++, x += pen.Width)
                {
                    pen.Color = Divcode[1, i] == 0 ? Color.White : Color.Black;
                    g.DrawLine(pen, x, 0, x, y);
                }

                //Правая половина кода
                y = LINE_LEN * DPI;
                for (int i = 6; i < barCodeNum.Length; i++, textPt.X += textSpace)
                {
                    n = int.Parse(barCodeNum[i].ToString());
                    textPt.X = x;
                    g.DrawString(barCodeNum[i].ToString(), f, Brushes.Black, textPt);
                    for (int j = 0; j < Rcode.GetLength(1); j++, x += pen.Width)
                    {
                        pen.Color = Rcode[n, j] == 0 ? Color.White : Color.Black;
                        g.DrawLine(pen, x, 0, x, y);
                    }
                }
                //Разделитель справа
                y = SEPARATOR_LINE_LEN * DPI;
                for (int i = 0; i < 3; i++, x += pen.Width)
                {
                    pen.Color = Divcode[2, i] == 0 ? Color.White : Color.Black;
                    g.DrawLine(pen, x, 0, x, y);
                }
                g1.FillRectangle(Brushes.White, 0, 0, fullImage.Width, fullImage.Height);
                g1.DrawImage(barCodeBmp, DPI * SPACE_LEFT, DPI * SPACE_UP_DOWN);
            }

            return fullImage;
            //return barCodeBmp;
        }

        /*static internal void SaveBarCodeToFile(string path, string barCodeNum)
        {
            Bitmap bmp = DrawEAN13(barCodeNum);
            bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp.Dispose();
        }*/

        static internal bool CheckControlNumber(string barCodeNum)
        {
            int oddSum = 0;

            for (int i = 0; i < barCodeNum.Length - 1; i += 2)
            {
                oddSum += int.Parse(barCodeNum[i].ToString());
            }

            oddSum *= 3;

            for (int i = 1; i < barCodeNum.Length - 1; i += 2)
            {
                oddSum += int.Parse(barCodeNum[i].ToString());
            }

            int last = 10 - (oddSum % 10);

            return (last % 10) == int.Parse(barCodeNum[barCodeNum.Length - 1].ToString());
        }

    }
}
