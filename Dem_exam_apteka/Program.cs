using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dem_exam_apteka
{
    internal static class Program
    {
        public static chemist_shopEntities8 wftDb = new chemist_shopEntities8();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OrderCreate());
            //Application.Run(new Laborant());
        }
    }
}
