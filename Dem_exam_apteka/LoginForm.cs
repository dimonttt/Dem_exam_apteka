using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Dem_exam_apteka
{
    public struct User
    {
        public string login;
        public string password;
        public string type;
        public string name;

    }



    public partial class LoginForm : Form
    {
        public int s = 0;
        public int s1 = 0;
        public int m1 = 30;
        public int h1 = 0;
        public static User users = new User();
        //public static BlocedLoginAndPass blocedLoginAndPass = new BlocedLoginAndPass();
        
    public LoginForm()
        {
            InitializeComponent();

           
            passFied.UseSystemPasswordChar = true;

            
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closebutton_MouseEnter(object sender, EventArgs e)
        {
            closebutton.ForeColor = Color.FromArgb(73, 140, 81);
        }

        private void closebutton_MouseLeave(object sender, EventArgs e)
        {
            closebutton.ForeColor = Color.FromArgb(255, 255, 255);
        }

        Point lastPoint;
        private string text;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //если логин и пароль пустые
            if (this.loginField.Text == "" && this.passFied.Text == "")
            {
                MessageBox.Show("Введите данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //если логин и пароль ввели
            else
            {
                bool key = false;
                //ищем в базе данных пользователя с такими логином и паролем и запоминаем их
                foreach (Users user in Program.wftDb.Users) 
                {
                    if (this.loginField.Text == user.login && this.passFied.Text == user.password)
                    {
                        key = true;
                        
                        users.login = user.login;
                        users.password = user.password;
                        users.type = user.type;
                        users.name = user.name;
                    }


                }
                // если пользователя не нашли
                if (!key)
                {
                    MessageBox.Show("Проверьте данные", "Пользователь не найден", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loginField.Text = "";
                    passFied.Text = "";

                    pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
                    this.textBox1.Visible = true;
                    this.button1.Visible = true;
                    this.button2.Visible = true;

                    this.loginField.Enabled = false;
                    this.passFied.Enabled = false;
                }
                // если пользователя нашли
                else
                {

                    MessageBox.Show("Данные введены верно", "Пользователь найден", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (users.type == "1")
                    {
                        Laborant laborant = new Laborant();
                        laborant.Show(); this.Hide();
                    }
                    if (users.type == "2")
                    {
                        Buhgalter buhgalter = new Buhgalter();
                        buhgalter.Show(); this.Hide();
                    }
                    if (users.type == "3")
                    {
                        Admin admin = new Admin();
                        admin.Show(); this.Hide(); 
                    }

                }
            }
        }

        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = 10;
            int Ypos = 10;

            //Добавим различные цвета ддя текста
            Brush[] colors = {
            Brushes.Black,
            Brushes.Red,
            Brushes.RoyalBlue,
            Brushes.Green,
            Brushes.Yellow,
            Brushes.White,
            Brushes.Tomato,
            Brushes.Sienna,
            Brushes.Pink };

            //Добавим различные цвета линий
            Pen[] colorpens = {
            Pens.Black,
            Pens.Red,
            Pens.RoyalBlue,
            Pens.Green,
            Pens.Yellow,
            Pens.White,
            Pens.Tomato,
            Pens.Sienna,
            Pens.Pink };

            //Делаем случайный стиль текста
            FontStyle[] fontstyle = {
            FontStyle.Bold,
            FontStyle.Italic,
            FontStyle.Regular,
            FontStyle.Strikeout,
            FontStyle.Underline};

            //Добавим различные углы поворота текста
            Int16[] rotate = { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5, 6, -6 };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((System.Drawing.Image)result);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Делаем случайный угол поворота текста
            g.RotateTransform(rnd.Next(rotate.Length));

            //Генерируем текст
            text = String.Empty;
            string ALF = "7890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 4; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text, new Font("Arial", 25, fontstyle[rnd.Next(fontstyle.Length)]),
            colors[rnd.Next(colors.Length)],
            new PointF(Xpos, Ypos));

            //Добавим немного помех
            //Линии из углов
            g.DrawLine(colorpens[rnd.Next(colorpens.Length)],
            new Point(0, 0),
            new Point(Width - 1, Height - 1));
            g.DrawLine(colorpens[rnd.Next(colorpens.Length)],
            new Point(0, Height - 1),
            new Point(Width - 1, 0));

            //Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == this.text)
            {
                MessageBox.Show("Верно!");

                this.loginField.Enabled = true;
                this.passFied.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ошибка! Блокировка входа на 10 сек.");
                timer1.Start();
                textBox1.Text = "";
                textBox1.Clear();
                textBox1.Enabled = false;
            }
        }

        private void buttonNotVisible_Click(object sender, EventArgs e)
        {
            passFied.UseSystemPasswordChar = true;
        }

        private void buttonVisible_Click(object sender, EventArgs e)
        {
            passFied.UseSystemPasswordChar = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            s = s - 1;
            if (s == -1)
            {
                s = 10;
            }
            if (s == 0)
            {
                timer1.Stop();
                MessageBox.Show("Введите CARTHA снова.");
                
                textBox1.Enabled = true;

            }
        }
        internal void ZapuskTimer()
        {
            timer2.Start();
            this.loginField.Enabled = false;
            this.passFied.Enabled = false;
        }
        public void timer2_Tick(object sender, EventArgs e)
        {

            s1 = s1 - 1;
            if (s1 == -1)
            {
                m1 = m1 - 1;
                s1 = 59;
            }

            if (m1 == -1)
            {
                h1 = h1 - 1;
                m1 = 59;
            }

            if (h1 == 0 && m1 == 0 && s1 == 0)
            {
                timer2.Stop();
                MessageBox.Show("Введите логин и пароль!");
                this.loginField.Enabled = true;
                this.passFied.Enabled = true;
                this.labelHour.Visible = false;
                this.labelMin.Visible = false;
                this.labelSec.Visible = false;
                this.labelDvoetoch.Visible = false;
                this.labelDvoetoch2.Visible = false;
            }
            labelHour.Text = Convert.ToString(h1);
            labelMin.Text = Convert.ToString(m1);
            labelSec.Text = Convert.ToString(s1);
            
        }

        internal void timer2_Tick(Action<object, EventArgs> timer2_Tick)
        {
            
        }


    }
    
}
