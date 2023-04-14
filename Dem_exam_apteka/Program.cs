using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dem_exam_apteka
{
    internal static class Program
    {
        public static chemist_shopEntities4 wftDb = new chemist_shopEntities4();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());
            Application.Run(new Laborant());
        }
    }
}
